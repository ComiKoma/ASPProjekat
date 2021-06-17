using ASPProjekat.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.API.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0; //0

        public string Identity => "Anonymous User";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 2, 3, 7 };
    }
}
