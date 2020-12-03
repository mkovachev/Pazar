using AutoMapper;
using Pazar.Core.Mappings;
using Pazar.Identity.Data.Models;

namespace Pazar.Identity.Models
{
    public class UserVm : IMapFrom<User>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
         => profile
             .CreateMap<User, UserVm>().ReverseMap();
    }
}
