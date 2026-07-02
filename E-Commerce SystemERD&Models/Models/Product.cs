using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce_SystemERD_Models.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; } // system generated

        [Required]
        [MaxLength(150)]
        public string productName { get; set; } // user input

        [MaxLength(1000)]
        public string? description { get; set; } // user input

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal price { get; set; } // user input

        [Required]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int stockQuantity { get; set; } // default value

        [MaxLength(300)]
        public string? imageUrl { get; set; } // user input

        [ForeignKey("Category")]
        public int categoryId { get; set; } // foreign key

        public Category Category { get; set; } // navigation property

        [Required]
        public DateTime createdAt { get; set; } // system generated

        [DefaultValue(true)]
        public bool isAvailable { get; set; } // default value    }
    }
}
