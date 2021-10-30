using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curatio.Models.Form3
{
    public class FilterForm3
    {
        public int? Id { get; set; }
        public string Company { get; set; }
        public string DoctorName { get; set; }
        public DateTime? Date { get; set; }
        public string FullName { get; set; }
        public string Province { get; set; }
        public string PrivateId { get; set; }
    }
}
