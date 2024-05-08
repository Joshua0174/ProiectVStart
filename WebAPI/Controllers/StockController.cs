using BusinessLayer.Dtos.StockDto;
using DataAccessLayer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Mappers;
using BusinessLayer.Contracts;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IStockService _stockService;
        public StockController(MyDbContext context, IStockService stocServ) {
            _context = context;
            _stockService=stocServ;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            var stockDto=stocks.Select(s => s.ToStockDto());
            return Ok(stocks);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockService.GetByIdAsync(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel= stockDto.ToStockFromCreateDto();
            await _stockService.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task< IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto){

            var stockModel = await _stockService.UpdateAsync(id, updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            var stockModel = await _stockService.DeleteAsync(id);
           if(stockModel == null) {
               return NotFound();
           }
          
           return NoContent();
        }
    }

}
