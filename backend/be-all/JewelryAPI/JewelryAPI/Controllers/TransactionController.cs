﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Repositories.QueryObjects;
using Services;

namespace JewelryAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class TransactionController : Controller
    {
        private TransactionService _transactionService = new();

        [HttpGet]
        public IActionResult GetTransaction([FromQuery] TransactionQueryObject queryObject)
        {

            List<Transaction> transactionList = new List<Transaction>();
            try
            {
                transactionList = _transactionService.GetTransaction(queryObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(transactionList);
        }
        [HttpGet("TotalMoney")]
        public IActionResult TotalMoneyTransactedByATimePeriod(DateOnly begin, DateOnly end)
        {
            try
            {
              
                decimal totalMoney = _transactionService.TotalMoneyTransactedByATimePeriod(begin, end);
                return Ok(totalMoney);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("TotalMoneyForEachMonth")]
        public IActionResult TotalMoneyForEachMonth(DateOnly year)
        {
            try { 
             var  totalMoney = _transactionService.TotalMoneyForEachMonth(year);
                return Ok(totalMoney);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddNewTransaction")]
        public IActionResult PostTransaction(Transaction transaction)
        {
            try
            {
                _transactionService.AddTransaction(transaction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
            return Ok(new { Success = true, Data = transaction });

        }
    }
}
