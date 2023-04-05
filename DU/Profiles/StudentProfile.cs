using AutoMapper;
using DU.DTO;
using DU.Model;

namespace DU.Profiles

{
    public class StudentProfile :Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ForMember(dto => dto.Id, option => option.MapFrom(usr => usr.Id)).
                ReverseMap(); //can chain
        }
    }
}
