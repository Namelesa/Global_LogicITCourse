using Evenza.Domain.BaseInterface;
using UserModel = Evenza.Domain.User.User;

namespace Evenza.Domain.Event;

public interface IEventRepository : IRepository<Event>
{
    Task<List<Event>> GetEventsByAuthorIdAsync(Guid authorId);
    Task<Event> FindEventByIdAsync(Guid eventId);
    Task<List<Event>> GetEventsUserParticipatesAsync(Guid userId);
    Task<Event> AddUserToEventAsync(UserModel user, Guid eventId);
    Task<Event> DeleteUserFromEventAsync(UserModel user, Guid eventId);
    Task<List<Event>> GetEventsAsync(DateTime startDate, DateTime endDate, int? categoryId);
    Task<IEnumerable<UserModel>> GetUsersByEventIdAsync(Guid id);
}