﻿using System.ComponentModel.DataAnnotations;

namespace Clothes.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Order Order { get; set; }

        public decimal TotalPrice => Price * Quantity;
    }
}
