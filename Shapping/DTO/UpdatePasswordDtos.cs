﻿using System.ComponentModel.DataAnnotations;

namespace Shapping.DTO
{
    public class UpdatePasswordDtos
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
