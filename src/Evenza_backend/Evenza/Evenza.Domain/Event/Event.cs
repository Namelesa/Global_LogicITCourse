namespace Evenza.Domain.Event;

public class Event
{
    private readonly List<User.User> _participates = [];
    private Event(string eventName, string description, Guid authorId, int userCounter, Category.Category category)
    {
        Id = Guid.NewGuid();
        Name = eventName;
        Description = description;
        AuthorId = authorId;
        UserCounter = userCounter;
        Category = category;
    }
    
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorId { get; set; }
    public virtual User.User Author { get; set; }
    public int UserCounter { get; set; }

    public IReadOnlyCollection<User.User> Users => _participates.AsReadOnly();
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public Category.Category Category { get; set; }
    
    public static Event Create(string eventName, string description, Guid authorId, int userCounter, Category.Category category)
    {
        return new Event(eventName, description, authorId, userCounter, category);
    }
    
    public void AddUser(User.User user)
    {
        if (_participates.Contains(user))
            return;

        if (UserCounter == 0)
            return;
        
        _participates.Add(user);
        UserCounter++;
    }
    
    public void RemoveUser(User.User user)
    {
        if (!_participates.Contains(user))
            return;
        
        _participates.Remove(user);
        UserCounter--;
    }
    
    public void Update(string eventName, string description, DateTime startTime, DateTime endTime, Category.Category category)
    {
        Name = eventName;
        Description = description;
        Category = category;
        StartTime = startTime;
        EndTime = endTime;
    }
}