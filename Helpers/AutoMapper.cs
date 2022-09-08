using AutoMapper;
using Org.DTOs;
using Org.Models;

namespace Org.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Register, RegisterDTO>().ReverseMap();
            CreateMap<RegisterCreationDTOs, Register>();
            CreateMap< Invite, InviteDTO>().ReverseMap();
            CreateMap<InviteCreationDTO, Invite>();
            CreateMap<ActOnInvitationDTO,ActOnInvitations>();
            CreateMap<Invite, ViewConnectionDTO>();
            CreateMap<Invite, SentInviteDTO>();
        }
    }
}
