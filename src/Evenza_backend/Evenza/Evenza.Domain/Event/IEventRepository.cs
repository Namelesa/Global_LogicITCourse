using Evenza.Domain.BaseInterface;

namespace Evenza.Domain.Event;

public interface IEventRepository : IRepository<Event>
{
    Task<List<Event>> GetEventsByAuthorIdAsync(Guid authorId);
    Task<List<Event>> GetEventsByUserIdAsync(Guid userId);
    Task<string> AddUserToEventAsync(Guid userId);
    Task<string> DeleteUserToEventAsync(Guid userId);
    Task<List<Event>> GetEventsByDateAsync(DateTime startDate, DateTime endDate);
    Task<List<Event>> GetEventsByCategoryNameAsync(List<string> categoriesNames);
}