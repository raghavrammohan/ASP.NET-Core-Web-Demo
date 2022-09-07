﻿using Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductModule.Models
{
    [Table("product_category")]
    public class ProductCategory : BaseEntity
    {
        [Key] public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
