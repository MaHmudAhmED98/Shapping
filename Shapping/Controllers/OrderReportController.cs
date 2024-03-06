﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shapping.DTO;
using Shapping.Handler;
using Shapping.Model;

namespace Shapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReportController : ControllerBase
    {
        private readonly IOrderHandler orderHandler;

        public OrderReportController(IOrderHandler orderHandler)
        {
            this.orderHandler = orderHandler;
        }
        [HttpGet]
        [Route("GetAllOrder")]
        public ActionResult<IEnumerable<ReadOrderReportsDto>> GetAllOrder(int pageNubmer, int pageSize)
        {
            return Ok(orderHandler.GetAll(pageNubmer, pageSize));
        }



        [HttpGet]
        [Route("CountAll")]
        public ActionResult<int> CountAll()
        {
            return Ok(orderHandler.CountAll());
        }


        [HttpGet]
        [Route("SearchByDateAndStatus")]
        public ActionResult<IEnumerable<ReadOrderReportsDto>> SearchByDateAndStatus(int pageNubmer, int pageSize, DateTime fromDate, DateTime toDate, Status status)
        {
            return Ok(orderHandler.SearchByDateAndStatus(pageNubmer, pageSize, fromDate, toDate, status));
        }


        [HttpGet]
        [Route("CountOrdersByDateAndStatus")]
        public ActionResult<int> CountOrdersByDateAndStatus(DateTime fromDate, DateTime toDate, Status status)
        {
            return Ok(orderHandler.CountOrdersByDateAndStatus(fromDate, toDate, status));
        }


    }
}
