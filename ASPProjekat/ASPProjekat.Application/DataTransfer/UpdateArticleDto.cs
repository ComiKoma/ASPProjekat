using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.DataTransfer
{
    public class UpdateArticleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public string Picture { get; set; }
        public bool OnSale { get; set; }
        public int OnStock { get; set; }
        public decimal OldPrice { get; set; }

        public decimal NewPrice { get; set; }
        public IFormFile ImageObj { get; set; }
    }
}
