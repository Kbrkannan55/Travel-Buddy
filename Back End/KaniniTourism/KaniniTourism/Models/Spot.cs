﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaniniTourism.Models
{
    public class Spot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? SpotName { get; set; }
        public int? SpotDuration { get; set; }
        [ForeignKey("Id")]
        public Place? PlaceId { get; set; }

        public ICollection<Place> Places { get; set;}
    }
}
