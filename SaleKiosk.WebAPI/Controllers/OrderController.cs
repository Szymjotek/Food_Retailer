﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleKiosk.Application.Services;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var result = _orderService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] OrderDto dto)
        {
            try
            {
                var id = _orderService.Create(dto);

                var actionName = nameof(Get);
                var routeValues = new { id };
                return CreatedAtAction(actionName, routeValues, null);
            }
            catch(ApplicationException ex)
            {
                return StatusCode(400, $"Customer ID error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
