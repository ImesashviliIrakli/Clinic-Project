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
        IEnumerable<Form3> FilteredForm3s(int formId);
        IEnumerable<Form3> FilteredForm3s(FilterForm3 body);
        Form3 GetFormThreeById(int formId);
    }
}
