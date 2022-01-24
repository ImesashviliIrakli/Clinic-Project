using Curatio.Models.Form3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curatio.Repository
{
    public interface IFormThree
    {
        IEnumerable<Form3> GetAllForm3s();
        Form3 GetFormThreeById(int formId);
        void CreateFormThree(Form3 body);
        void UpdateFormThree(Form3 body);
        IEnumerable<Form3> FilteredForm3(int formId);
        IEnumerable<Form3> FilteredForm3s(FilterForm3 body);
    }
}
