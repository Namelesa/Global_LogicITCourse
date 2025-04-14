using Evenza.Domain.BaseInterface;

namespace Evenza.Domain.User;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetUsersByEventIdAsync(Guid id);
}