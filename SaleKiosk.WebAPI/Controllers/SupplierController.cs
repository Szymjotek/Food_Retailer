using Microsoft.AspNetCore.Mvc;
using SaleKiosk.Application.Services;
using SaleKiosk.Domain.Exceptions;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.SharedKernel.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly ILogger<SupplierController> _logger;

        //private readonly IValidator<CreateProductDto> _validator;

        //public ProductController(IProductService productService, IValidator<CreateProductDto> validator)
        //{
        //    this._productService = productService;
        //    _validator = validator;
        //}

        public SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger)
        {
            this._supplierService = supplierService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDto>> Get()
        {
            var result = _supplierService.GetAll();
            _logger.LogDebug("Pobrano listę wszystkich dostawcow");
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetSupplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SupplierDto> Get(int id)
        {
            var result = _supplierService.GetById(id);
            _logger.LogDebug($"Pobrano dostawce o id = {id}");
            return Ok(result);
        }


        // return CreatedAtAction() - dynamicznie twrozony url
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateSupplierDto dto)
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

            var id = _supplierService.Create(dto);

            _logger.LogDebug($"Utworzono nowego dostawce z id = {id}");
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            _supplierService.Delete(id);
            _logger.LogDebug($"Usunieto dostawce z id = {id}");
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateSupplierDto dto)
        {
            if (id != dto.Id)
            {
                throw new BadRequestException("Id param is not valid");
            }

            _supplierService.Update(dto);
            _logger.LogDebug($"Zaktualizowano dostawce z id = {id}");
            return NoContent();
        }
    }
}
