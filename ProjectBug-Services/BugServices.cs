using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectBug_Entities;
using ProjectBug_Services.DTO;
using static System.Formats.Asn1.AsnWriter;

namespace ProjectBug_Services
{
    public class BugServices : IBugServices
    {
        private IMapper _mapper;
        private DataContext _context;

        public BugServices(DataContext context,
                              IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Delete(int bugId)
        {
            throw new NotImplementedException();
        }

        int IBugServices.Create(BugInput bugInput)
        {
            var bug = _mapper.Map<Bug>(bugInput);
            _context.Add(bug);
            _context.SaveChanges();
            return bug.Id;
        }

        BugOutput IBugServices.Find(int bugId)
        {
            var bug = _context.Bugs
                           .Include(x => x.Project)
                           .Include(x => x.RelatedUser)
                           .FirstOrDefault(x => x.Id == bugId);
            var result = _mapper.Map<BugOutput>(bug);
            return result;
        }

        BugOutputList IBugServices.FindAll(BugFilter filter)
        {
            IQueryable<Bug> baseQuery = _context.Bugs;


            if (filter.UserId != null && filter.UserId > 0)
            {
                baseQuery = baseQuery.Where(x => x.UserId == filter.UserId);
            }
            if (filter.ProjectId != null && filter.ProjectId > 0)
            {
                baseQuery = baseQuery.Where(x => x.ProjectId == filter.ProjectId);
            }
            if (filter.CreatedAt != null)
            {
                if (filter.CreatedAt.From != null)
                    baseQuery = baseQuery.Where(x => x.CreationDate >= filter.CreatedAt.From);
                if (filter.CreatedAt.To != null)
                    baseQuery = baseQuery.Where(x => x.CreationDate <= filter.CreatedAt.To);
            }
            var query = baseQuery
            .Include(x => x.Project)
            .Include(x => x.RelatedUser)
            .OrderByDescending(x => x.CreationDate)
            ;
            return new BugOutputList()
            {
                Bugs = new List<BugOutput>(_mapper.Map<List<BugOutput>>(query.ToList()))
            };
        }

        void IBugServices.Update(int bugId, BugInput bugInput)
        {
            var bug = _context.Bugs
                .FirstOrDefault(x => x.Id == bugId);

            if (bug != null)
            {
                bug.ProjectId = bugInput.Project;
                bug.UserId = bugInput.User;
                bug.Description = bugInput.Description;
                
                _context.Update(bug);
                _context.SaveChanges();
            }
        }
    }
}