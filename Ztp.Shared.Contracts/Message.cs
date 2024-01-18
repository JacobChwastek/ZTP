namespace Ztp.Shared.Contracts;

public abstract class Message
{
    protected Message()
    {
        MessageId = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
    
    public Guid MessageId { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public string CreatedBy { get; set; }
}