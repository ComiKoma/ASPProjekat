using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class CreateArticleDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public bool OnSale { get; set; }
        public int OnStock { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public IFormFile ImageObj { get; set; }
    }
}
