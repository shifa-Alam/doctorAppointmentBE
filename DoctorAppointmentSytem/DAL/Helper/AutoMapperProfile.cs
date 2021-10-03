

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserInputModel>().ReverseMap();
            CreateMap<Role, RoleInputModel>().ReverseMap();
            CreateMap<Doctor, DoctorInputModel>().ReverseMap();
            CreateMap<Patient, PatientInputModel>().ReverseMap();
            CreateMap<Appointment, AppointmentInputModel>().ReverseMap();
            //CreateMap<Product, ProductViewModel>().ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(y => y.Category.Name).ToList()));
        }
    }
}
