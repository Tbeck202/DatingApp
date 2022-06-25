using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        /* 
            Interesting note: Data will be returned as json and formatted in camel case,
            despite being defined in title case here. .NET converts the property names
            automatically to match the accepted conventions.
        */
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}