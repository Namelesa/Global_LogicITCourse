using Evenza.Domain.BaseInterface;

namespace Evenza.Domain.User;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindUserByIdAsync(Guid id);
    Task<User?> FindUserByEmailAsync(string email);
    Task AddSavedEventAsync(Guid userId, Event.Event @event);
    Task RemoveSavedEventAsync(Guid userId, Event.Event @event);
    Task AddCreatedEventAsync(Guid userId, Event.Event @event);
    Task RemoveCreatedEventAsync(Guid userId, Event.Event @event);
    Task AddJoinedEventAsync(Guid userId, Event.Event @event);
    Task RemoveJoinedEventAsync(Guid userId, Event.Event @event);
}