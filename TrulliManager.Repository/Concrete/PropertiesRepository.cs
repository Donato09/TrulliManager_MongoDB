using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TrulliManager.Database;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager.Repository.Concrete
{
  public class PropertiesRepository : IPropertiesRepository
  {
    private readonly TrulliContext _db;

    public PropertiesRepository(TrulliContext db)
    {
      _db = db;
    }

    public IMongoQueryable<Property> All()
    {
      return _db.Properties.AsQueryable();
    }

    public Property ByName(string name)
    {
      return _db.Properties.Find(document => document.Name.Equals(name)).FirstOrDefault();
    }

    public Property Create(Property property)
    {
      _db.Properties.InsertOne(property);
      return property;
    }

    public IEnumerable<Property> ByKeys(IEnumerable<string> propertyIds)
    {
      return All().Where(x => propertyIds.Contains(x._id));
    }
  }
}
