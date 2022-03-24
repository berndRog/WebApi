using Microsoft.EntityFrameworkCore;

using System.Diagnostics;
using WebApi.Model;
namespace WebApi.Data; 

public class CDbContext: DbContext  {

   public DbSet<Owner> Owners{ get; set; } = default!;

   public CDbContext(DbContextOptions<CDbContext> options)
        : base(options) {
   }
   public bool SaveAllChanges() {
      Debug.WriteLine(ChangeTracker.DebugView.LongView);
      var result = SaveChanges();
      Debug.WriteLine($"Result of SaveChanges {result}");
      Debug.WriteLine(ChangeTracker.DebugView.LongView);
      return result > 0;
   }
}