﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace KaniniTourism.Models
{


    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [ForeignKey("User")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Range(1, 5, ErrorMessage = "Adult count must be at least 1.")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Package ID is required.")]
        [ForeignKey("Package")]
        public int? PackageID { get; set; }

        public ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
    }

}