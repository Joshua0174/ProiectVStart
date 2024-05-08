﻿namespace BusinessLayer.Dtos.StockDto
{
    public class CreateStockRequestDto
    {

        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
