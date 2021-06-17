using ASPProjekat.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Application.Searches
{
    public class ArticleSearch:PagedSearch
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
