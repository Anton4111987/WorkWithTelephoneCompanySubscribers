using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTelephoneCompanySubscribers.Models
{
    public class Abonent
    {
        public int Id { get; set; }

        public string? FIO { get; set; }

        public int Address_Id { get; set; }
    }
}
