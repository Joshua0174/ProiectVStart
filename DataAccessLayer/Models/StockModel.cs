using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class StockModel
    {
       
        public int Id{get; set;}
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public List<ReviewModel> Reviews { get; set; }=new List<ReviewModel>();
    }
}
