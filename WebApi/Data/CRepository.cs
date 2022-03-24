using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

using WebApi.Model;
namespace WebApi.Data; 

public class CRepository: IRepository {

   private readonly CDbContext _dbContext;

   public CRepository(CDbContext dbContext) {
      _dbContext = dbContext;
   }

   public IEnumerable<Owner> Select() 
      => _dbContext.Owners.ToList();
   
   public Owner? FindById(Guid id) 
      => _dbContext.Owners.FirstOrDefault(o => o.Id == id);   

   public void Add(Owner owner) {
      var retrievedOwner = _dbContext.Owners.FirstOrDefault(o => o.Id == owner.Id);
      if(retrievedOwner != null)
         throw new ApplicationException($"Add failed, owner {owner.Id} already exists");
      _dbContext.Owners.Add(owner);
      _dbContext.SaveAllChanges();
   }
   
   public void Update(Owner owner) {
      var retrievedOwner = _dbContext.Owners.FirstOrDefault(o => o.Id == owner.Id);
      if (retrievedOwner == null)
         throw new ApplicationException($"Update failed, owner {owner.Id} not found");
      _dbContext.Owners.Remove(retrievedOwner);
      Add(owner);
   }

   public void Delete(Owner owner) {
      var retrievedOwner = _dbContext.Owners.FirstOrDefault(o => o.Id == owner.Id);
      if (retrievedOwner == null)
         throw new ApplicationException($"Deleted, owner {owner.Id} not found");
      _dbContext.Owners.Remove(owner);
      _dbContext.SaveAllChanges();
   }
}