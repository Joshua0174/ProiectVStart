using BusinessLayer.Dtos.StockDto;
using DataAccessLayer.Models;
using System.Diagnostics.SymbolStore;
//using WebAPI.Dtos.StockDto;

namespace BusinessLayer.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this StockModel stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                ProductName = stockModel.ProductName,
                Description = stockModel.Description,
                Price = stockModel.Price,
                Category = stockModel.Category,
            };
        }
        public static StockModel ToStockFromCreateDto(this CreateStockRequestDto createStockRequestDto)
        {
            return new StockModel
            {
                ProductName = createStockRequestDto.ProductName,
                Description = createStockRequestDto.Description,
                Price = createStockRequestDto.Price,
                Category = createStockRequestDto.Category,
            };
        }
    }
}
