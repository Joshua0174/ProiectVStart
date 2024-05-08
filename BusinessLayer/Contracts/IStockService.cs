using BusinessLayer.Dtos.StockDto;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface IStockService
    {
        Task<List<StockModel>> GetAllAsync();
        Task<StockModel?> GetByIdAsync(int id); //pentru ca firstOrDefeault poate fi null
        Task<StockModel> CreateAsync(StockModel stockModel);
        Task<StockModel> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<StockModel> DeleteAsync(int id);
    }
}
