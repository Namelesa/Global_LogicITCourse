namespace Evenza.Domain.User;

public class User
{
    private readonly List<Event.Event> _savedEvents = [];
    private readonly List<Event.Event> _createdEvents = [];
    private readonly List<Event.Event> _joinedEvents = [];
    
    private User(string userName, string email, string password)
    {
        Id = Guid.NewGuid();
        UserName = userName;
        Email = email;
        Password = password;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
    }
    public Guid Id { get; set; }

    public string UserName { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public IReadOnlyCollection<Event.Event> SavedEvents => _savedEvents.AsReadOnly();
    public IReadOnlyCollection<Event.Event> CreatedEvents => _createdEvents.AsReadOnly();
    public IReadOnlyCollection<Event.Event> JoinedEvents => _joinedEvents.AsReadOnly();
    
    
    public static User Create(string userName, string email, string password)
    {
        return new User(userName, email, password);
    }
    
    public void AddSavedEvent(Event.Event eventItem)
    {
        if (_savedEvents.Contains(eventItem))
            return;
        
        _savedEvents.Add(eventItem);
    }
    
    public void RemoveSavedEvent(Event.Event eventItem)
    {
        if (!_savedEvents.Contains(eventItem))
            return;
        
        _savedEvents.Remove(eventItem);
    }
    
    public void AddCreatedEvent(Event.Event eventItem)
    {
        if (_createdEvents.Contains(eventItem))
            return;
        
        _createdEvents.Add(eventItem);
    }
    
    public void RemoveCreatedEvent(Event.Event eventItem)
    {
        if (!_createdEvents.Contains(eventItem))
            return;
        
        _createdEvents.Remove(eventItem);
    }
    
    public void AddJoinedEvent(Event.Event eventItem)
    {
        if (_joinedEvents.Contains(eventItem))
            return;
        
        _joinedEvents.Add(eventItem);
    }
    
    public void RemoveJoinedEvent(Event.Event eventItem)
    {
        if (!_joinedEvents.Contains(eventItem))
            return;
        
        _joinedEvents.Remove(eventItem);
    }
    
    public void Update(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
        UpdatedAt = DateTime.UtcNow;
    }
    
}