namespace Data.Domains.Models;

public class PersonContactDbModel
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string Phone { get; set; }
    
}