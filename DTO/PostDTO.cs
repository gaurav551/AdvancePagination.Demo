using System;
using Microsoft.AspNetCore.Http;

namespace AdvancePagination.Demo.DTO
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}