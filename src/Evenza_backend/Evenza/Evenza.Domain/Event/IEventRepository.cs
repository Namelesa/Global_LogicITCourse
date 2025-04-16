using Evenza.Domain.BaseInterface;

namespace Evenza.Domain.Event;

public interface IEventRepository : IRepository<Event>
{
    Task<List<Event>> GetEventsByAuthorIdAsync(Guid authorId);
    Task<List<Event>> GetEventsUserParticipatesAsync(Guid userId);
    Task<Event> AddUserToEventAsync(Guid userId);
    Task<Event> DeleteUserToEventAsync(Guid userId);
    Task<List<Event>> GetEventsAsync(DateTime startDate, DateTime endDate, int? categoryId);
}