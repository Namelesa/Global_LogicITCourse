namespace Evenza.Domain.Event;

public class Event
{ 
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public int UserCounter { get; set; }
    
    public IReadOnlyCollection<User.User> Users { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public Guid CategoryId { get; set; }
}