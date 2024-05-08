using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Dtos.StockDto
{
    public class StockDto
    {


        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
