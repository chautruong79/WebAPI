using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex4.Entities;
using Ex4.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceMechandisingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceMechandisingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST api/<InvoiceMechandisingController>/Stock
        [HttpPost]
        [Route("Stock")]
        public async Task<ActionResult> CreateStock([FromBody] Stock stock)
        {
            try
            {
                if (stock == null)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.StockTypes.IsExist(s => s.StockTypeID == stock.StockTypeID))
                {
                    return NotFound();
                }
                await _unitOfWork.Stocks.Create(stock);
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(CreateStock), new { Id = stock.StockID }, stock);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        private async Task<bool> CreateReceiptDetail(ReceiptDetail receiptDetail)
        {
            try
            {
                if (!await _unitOfWork.Receipts.IsExist(s => s.ReceiptID == receiptDetail.ReceiptID) || !await _unitOfWork.Stocks.IsExist(s => s.StockID == receiptDetail.StockID))
                {
                    return false;
                }
                Stock st = await _unitOfWork.Stocks.FindById((int)receiptDetail.StockID);
                if (st.StockQuantity < receiptDetail.SoldQuantity)
                {
                    return false;
                }
                st.StockQuantity -= receiptDetail.SoldQuantity;
                Receipt rc = await _unitOfWork.Receipts.FindById((int)receiptDetail.ReceiptID);
                rc.TotalAmount += receiptDetail.SoldQuantity * st.Price;
                await _unitOfWork.ReceiptDetails.Create(receiptDetail);
                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }

        // POST api/<InvoiceMechandisingController>/Receipt/5
        [HttpPost("{id}")]
        [Route("Receipt/{id}")]
        public async Task<ActionResult> CreateListReceiptDetail(int id, [FromBody] List<ReceiptDetail> listReceiptDetails)
        {
            try
            {
                if (id <= 0 || listReceiptDetails.Count == 0 || listReceiptDetails.Any(r => r.ReceiptID != id))
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.Receipts.IsExist(r => r.ReceiptID == id))
                {
                    return NotFound();
                }
                bool result = true;
                foreach (var r in listReceiptDetails)
                {
                    result = await CreateReceiptDetail(r);
                    if (!result)
                    {
                        break;
                    }
                };
                if (!result)
                {
                    return BadRequest();
                }
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(CreateListReceiptDetail), listReceiptDetails);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        //public async Task<ErrorType> CreateReceipt(Receipt receipt)
        //{
        //    try
        //    {
        //        await _unitOfWork.Receipts.Create(receipt);
        //        await _unitOfWork.CommitAsync();
        //        Console.WriteLine("Do You Want To Create A New List Of Receipt Details?(y/N): ");
        //        char answer = Console.ReadKey().KeyChar;
        //        Console.WriteLine();
        //        if (char.ToLower(answer) == 'y')
        //        {
        //            ErrorType et = await CreateListReceiptDetail(EntryListReceiptDetail(receipt.ReceiptID));
        //            if (et != ErrorType.Success)
        //            {
        //                _unitOfWork.Receipts.Delete(receipt);
        //                await _unitOfWork.CommitAsync();
        //                return et;
        //            }
        //        }
        //        else
        //        {
        //            _unitOfWork.Receipts.Delete(receipt);
        //            await _unitOfWork.CommitAsync();
        //            return ErrorType.Failed;
        //        }
        //        await _unitOfWork.CommitAsync();
        //        return ErrorType.Success;
        //    }
        //    catch (Exception)
        //    {
        //        _unitOfWork.Dispose();
        //        return ErrorType.Failed;
        //    }
        //}

        public async Task<bool> DeleteListReceiptDetail(int receiptID)
        {
            try
            {
                IEnumerable<ReceiptDetail> listReceiptDetails = await _unitOfWork.ReceiptDetails.Find(r => r.ReceiptID == receiptID);
                foreach (var item in listReceiptDetails)
                {
                    Stock st = await _unitOfWork.Stocks.FindById((int)item.StockID);
                    st.StockQuantity += item.SoldQuantity;
                    _unitOfWork.Stocks.Update(st);
                }
                _unitOfWork.ReceiptDetails.DeleteRange(listReceiptDetails);
                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return false;
            }

        }

        // DELETE api/<InvoiceMechandisingController>/Receipt/5
        [HttpDelete("{id}")]
        [Route("Receipt/Delete/{id}")]
        public async Task<ActionResult<Receipt>> DeleteReceipt(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.Receipts.IsExist(s => s.ReceiptID == id))
                {
                    return NotFound();
                }
                bool result = await DeleteListReceiptDetail(id);
                if (!result)
                {
                    return BadRequest();
                }
                Receipt receipt = await _unitOfWork.Receipts.FindById(id);
                _unitOfWork.Receipts.Delete(receipt);
                await _unitOfWork.CommitAsync();
                return Ok(receipt);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // GET: api/<InvoiceMechandisingController>/CalculateRevenue
        [HttpGet]
        [Route("CalculateRevenue")]
        public async Task<ActionResult> ReceiptInformation(int day, int month, int year)
        {
            try
            {
                if (year <= 2000 || year > DateTime.Now.Year || month < 1 || month > 12 || day <= 0 || day > DateTime.DaysInMonth(year, month))
                {
                    return BadRequest();
                }
                IEnumerable<Receipt> listReceipts = await _unitOfWork.Receipts.Find(r => r.DateCreated.Value.Year == year && r.DateCreated.Value.Month == month && r.DateCreated.Value.Day == day);
                List<object> information = new List<object>();
                foreach (var r in listReceipts)
                {
                    List<object> receiptInfo = new List<object>();
                    var info = new { ReceiptId= r.ReceiptID, DateCreated= r.DateCreated.Value.ToShortDateString(), r.StaffCreated, r.TotalAmount};
                    receiptInfo.Add(info);
                    IEnumerable<ReceiptDetail> receiptDetails = await _unitOfWork.ReceiptDetails.Find(d => d.ReceiptID == r.ReceiptID);
                    foreach (var c in receiptDetails)
                    {
                        Stock stock = await _unitOfWork.Stocks.FindById((int)c.StockID);
                        object detail = new { stock.StockName, c.SoldQuantity, stock.Price };
                        receiptInfo.Add(detail);
                    }
                    information.Add(receiptInfo);
                }
                return Ok(information);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }
    }
}
