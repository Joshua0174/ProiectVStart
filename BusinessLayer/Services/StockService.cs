using BusinessLayer.Contracts;
using BusinessLayer.Dtos.StockDto;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StockService : IStockService
    {   
        private readonly MyDbContext _context;
        public StockService(MyDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<StockModel> CreateAsync(StockModel stockModel)
        {
            await _context.StockModels.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<StockModel> DeleteAsync(int id)
        {
           var stockModel= await _context.StockModels.FirstOrDefaultAsync(x=>x.Id==id);
            if (stockModel == null)
            {
                return null;
            }
            _context.StockModels.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<StockModel>> GetAllAsync()
        {
            return await _context.StockModels.ToListAsync();
        }

        public async Task<StockModel?> GetByIdAsync(int id)
        {
            return await _context.StockModels.FindAsync(id);
        }

        public async Task<StockModel> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock=await _context.StockModels.FirstOrDefaultAsync(x=> x.Id==id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.ProductName = stockDto.ProductName;
            existingStock.Description = stockDto.Description;
            existingStock.Price = stockDto.Price;
            existingStock.Category = stockDto.Category;
            await _context.SaveChangesAsync();
            return existingStock;
        }
    }
}
