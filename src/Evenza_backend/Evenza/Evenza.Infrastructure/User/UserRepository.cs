using Evenza.Domain.User;
using Evenza.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UserModel = Evenza.Domain.User.User;

namespace Evenza.Infrastructure.User;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<UserModel> AddAsync(UserModel t)
    {
        var user = await db.Users.AddAsync(t);
        await db.SaveChangesAsync();
        return user.Entity;
    }

    public async Task<UserModel> EditAsync(UserModel t)
    {
        var user = db.Users.Update(t);
        await db.SaveChangesAsync();
        return user.Entity;
    }

    public async Task<UserModel> DeleteAsync(UserModel t)
    {
        var user = db.Users.Remove(t);
        await db.SaveChangesAsync();
        return user.Entity;
    }

    public async Task<UserModel?> FindUserByIdAsync(Guid id) =>
        await db.Users.FindAsync(id);
    
    public async Task<UserModel?> FindUserByEmailAsync(string email) =>
        await db.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddSavedEventAsync(Guid userId, Domain.Event.Event @event)
    {
        var user = await FindUserByIdAsync(userId);
        user?.AddSavedEvent(@event);
    }

    public async Task RemoveSavedEventAsync(Guid userId, Domain.Event.Event @event)
    {
        var user = await FindUserByIdAsync(userId);
        user?.RemoveSavedEvent(@event);
    }

    public async Task AddCreatedEventAsync(Guid userId, Domain.Event.Event @event)
    {
        var user = await FindUserByIdAsync(userId);
        user?.AddCreatedEvent(@event);
    }

    public async Task RemoveCreatedEventAsync(Guid userId, Domain.Event.Event @event)
    {
        var user = await FindUserByIdAsync(userId);
        user?.RemoveCreatedEvent(@event);
    }

    public async Task AddJoinedEventAsync(Guid userId, Domain.Event.Event @event)
    {
        var user = await FindUserByIdAsync(userId);
        user?.AddJoinedEvent(@event);
    }

    public async Task RemoveJoinedEventAsync(Guid userId, Domain.Event.Event @event)
    {
        var user = await FindUserByIdAsync(userId);
        user?.RemoveJoinedEvent(@event);
    }
}