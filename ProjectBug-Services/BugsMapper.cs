using AutoMapper;
using ProjectBug_Entities;
using ProjectBug_Services.DTO;

namespace ProjectBug_Services
{
    public class BugsMapper : Profile
    {
        public BugsMapper()
        {
            CreateMap<BugInput, Bug>()
                .ForMember(x => x.Description, s => s.MapFrom(i => i.Description))
                .ForMember(x => x.ProjectId, s => s.MapFrom(i => i.Project))
                .ForMember(x => x.UserId, s => s.MapFrom(i => i.User))
                .ForMember(x => x.Project, s => s.Ignore())
                .ForMember(x => x.RelatedUser, s => s.Ignore());

            CreateMap<Bug, BugOutput>()
                .ForMember(x => x.Project, s => s.MapFrom(i => i.Project.Name))
                .ForMember(x => x.Username, s => s.MapFrom(i => i.RelatedUser.Name +" "+ i.RelatedUser.Surname));
        }

    }
}
