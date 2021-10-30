using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curatio.Models.Form3
{
    public class Form3
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhone { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PrivateId { get; set; }
        public string Researches { get; set; }
        public bool Transport { get; set; }
        public string Comment { get; set; }
    }
}
