using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTelephoneCompanySubscribers.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }

        public string? Number { get; set; }

        public int Abonent_Id { get; set; }
    }
}
