using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce_SystemERD_Models.Models
{
    [Index(nameof(categoryName), IsUnique = true)]
    public class Category
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int categoryId { get; set; } // system generated

            [Required]
            [MaxLength(100)]
            public string categoryName { get; set; } // user input

            [StringLength(500)]
            public string? description { get; set; } // user input

            [StringLength(300)]
            public string? imageUrl { get; set; } // user input
        }
    }

