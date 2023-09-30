using ProjectBug_Services.DTO;

namespace ProjectBug_Services
{
    public interface IBugServices
    {
        int Create(BugInput bugInput);
        BugOutputList FindAll(BugFilter filter);
        void Delete(int bugId);
        BugOutput Find(int bugId);
        void Update(int bugId, BugInput bugInput);
    }
}