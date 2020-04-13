using System;
using System.ComponentModel.DataAnnotations;

namespace Training.Application.Dto
{
    public class VideoDto
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Duration { get; set; }

        [Required]
        [MaxLength(200)]
        public string DirectedBy { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
    }
}