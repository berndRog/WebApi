namespace WebApi.Model; 
public class Owner {
   public Guid     Id       { get; set; } = Guid.Empty;
   public string   Name     { get; set; } = string.Empty;
   public DateTime Birthdate{ get; set; } = DateTime.Now;
   public string   Email    { get; set; } = string.Empty;
}
