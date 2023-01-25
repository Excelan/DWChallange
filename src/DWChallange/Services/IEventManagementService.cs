using DWChallange.ViewModels.Event;

namespace DWChallange.Services
{
    public interface IEventManagementService
    {
        Task<ViewEvent?> Create(CreateEvent publicEvent);
        Task<ViewEvent?> Update(UpdateEvent publicEvent);
        Task Delete(ViewEvent publicEvent);
        Task<ViewEvent?> Find(int id);
        Task<UpdateEvent?> FindForUpdate(int id);
        bool Exists(int id);
        IQueryable<ViewEvent> GetAll();
    }
}
