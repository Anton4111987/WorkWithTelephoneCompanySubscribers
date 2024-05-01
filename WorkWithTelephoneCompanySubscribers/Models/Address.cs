using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTelephoneCompanySubscribers.Models
{
    public class Address
    {
        public int Id {  get; set; }

        public string? HouseNumber { get; set; } 
    
        public int Street_Id { get; set; }
    }
}
