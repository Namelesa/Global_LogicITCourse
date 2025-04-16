using Evenza.Domain.Category;
using Evenza.Domain.Event;
using Evenza.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EventModel = Evenza.Domain.Event.Event;
using UserModel = Evenza.Domain.User.User;

namespace Evenza.Infrastructure.Event;

public class EventRepository(AppDbContext db) : IEventRepository
{
    public async Task<EventModel> AddAsync(EventModel t)
    {
        var eventModel = await db.Events.AddAsync(t);
        await db.SaveChangesAsync();
        return eventModel.Entity;
    }

    public async Task<EventModel> EditAsync(EventModel t)
    {
        var eventModel = db.Events.Update(t);
        await db.SaveChangesAsync();
        return eventModel.Entity;
    }

    public async Task<EventModel> DeleteAsync(EventModel t)
    {
        var eventModel = db.Events.Remove(t);
        await db.SaveChangesAsync();
        return eventModel.Entity;
    }
    
    public async Task<EventModel> FindEventByIdAsync(Guid eventId) =>
        (await db.Events.FindAsync(eventId))!;

    public async Task<List<EventModel>> GetEventsByAuthorIdAsync(Guid authorId)
    {
        var eventList = db.Events.Where(u => u.AuthorId == authorId);
        return await eventList.ToListAsync();
    }

    public async Task<List<EventModel>> GetEventsUserParticipatesAsync(Guid userId)
    {
        return await db.Events
            .Include(e => e.Participates)
            .Where(e => e.Participates.Any(u => u.Id == userId))
            .ToListAsync();
    }

    public async Task<EventModel> AddUserToEventAsync(UserModel user, Guid eventId)
    {
        var eventModel = await FindEventByIdAsync(eventId);
        eventModel.AddUser(user);
        await db.SaveChangesAsync();
        return eventModel;
    }

    public async Task<EventModel> DeleteUserFromEventAsync(UserModel user, Guid eventId)
    {
        var eventModel = await FindEventByIdAsync(eventId);
        eventModel.RemoveUser(user);
        await db.SaveChangesAsync();
        return eventModel;
    }

    public async Task<List<EventModel>> GetEventsAsync(DateTime startDate, DateTime endDate, int? categoryId)
    {
        var query = db.Events.AsQueryable();

        query = query.Where(e => e.StartTime >= startDate && e.EndTime <= endDate);
        
        if (categoryId.HasValue)
            query = query.Where(e => e.Category == (Category)categoryId);

        return await query.ToListAsync();
    }
    
    public async Task<IEnumerable<UserModel>> GetUsersByEventIdAsync(Guid id)
    {
        var eventModel = await FindEventByIdAsync(id);
        return eventModel.Participates;
    }

}