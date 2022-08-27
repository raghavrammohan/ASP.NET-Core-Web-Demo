namespace ProductModule.Models;

public abstract class SystemEntity
{
    public DateTime createdAt { get; set; }
    public string createdBy { get; set; }
    public DateTime updatedAt { get; set; }
    public string updatedBy { get; set; }
}