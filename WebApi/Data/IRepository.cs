using WebApi.Model;
namespace WebApi.Data; 

public interface IRepository {
   // CRUD-Operation
   // Create  --> Add
   // Read    --> Find, Select
   // Update  --> Update
   // Delete  --> Delete
   
   IEnumerable<Owner> Select();
   Owner? FindById(Guid id);
   void Add(Owner owner);
   void Update(Owner owner);
   void Delete(Owner owner);
}