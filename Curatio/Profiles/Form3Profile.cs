using AutoMapper;
using Curatio.Models.Form3;

namespace Curatio.Profiles
{
    public class Form3Profile : Profile
    {
        public Form3Profile()
        {
            CreateMap<Form3ForCreation, Form3>();
            CreateMap<Form3ForUpdate, Form3>();
        }
    }
}
