using Microsoft.AspNetCore.Mvc;
using SaleKiosk.Application.Services;
using SaleKiosk.Domain.Exceptions;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.SharedKernel.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        //private readonly IValidator<CreateProductDto> _validator;

        //public ProductController(IProductService productService, IValidator<CreateProductDto> validator)
        //{
        //    this._productService = productService;
        //    _validator = validator;
        //}

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            this._customerService = customerService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            var result = _customerService.GetAll();
            _logger.LogDebug("Pobrano listę wszystkich produktów");
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDto> Get(int id)
        {
            var result = _customerService.GetById(id);
            _logger.LogDebug($"Pobrano klienta o id = {id}");
            return Ok(result);
        }


        // return CreatedAtAction() - dynamicznie twrozony url
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateCustomerDto dto)
        {
            // 1. Atrybut [ApiController]                               --> uruchamia automatyczną walidację
            // 2. Brak atrybutu [ApiController]                         --> automatyczna walidacja nie jest uruchamiania 
            // 3. Brak atrybutu [ApiController] + ModelState.IsValid    --> uruchamia walidację 
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var validationResult = _validator.Validate(dto);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult);
            //}

            var id = _customerService.Create(dto);

            _logger.LogDebug($"Utworzono nowy produkt z id = {id}");
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            _customerService.Delete(id);
            _logger.LogDebug($"Usunieto klienta z id = {id}");
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateCustomerDto dto)
        {
            if (id != dto.Id)
            {
                throw new BadRequestException("Id param is not valid");
            }

            _customerService.Update(dto);
            _logger.LogDebug($"Zaktualizowano klienta z id = {id}");
            return NoContent();
        }
    }
}
