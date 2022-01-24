using Curatio.Data;
using Curatio.Models.Form3;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curatio.Repository
{
    public class FormThreeRepository : IFormThree
    {
        private readonly AppDbContext _context;

        public FormThreeRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Form3> GetAllForm3s()
        {
            return _context.FormThree;
        }
        public Form3 GetFormThreeById(int formId)
        {
            return _context.FormThree.FirstOrDefault(f => f.Id == formId);
        }

        public void CreateFormThree(Form3 body)
        {
            if(body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            _context.FormThree.Add(body);
        }

        public void UpdateFormThree(Form3 body)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }
            _context.Entry(body).State = EntityState.Modified;
            _context.SaveChanges();
        }







        public IEnumerable<Form3> FilteredForm3(int formId)
        {
            return _context.FormThree.Where(f => f.Id == formId);
        }

        public IEnumerable<Form3> FilteredForm3s(FilterForm3 body)
        {
            return _context.FormThree.Where(
                f => f.Id == body.Id ||
                f.Company.Contains(body.Company) ||
                f.DoctorEmail.Contains(body.DoctorName) ||
                f.Date.Equals(body.Date) ||
                f.FullName.Contains(body.FullName));
        }
    }
}
