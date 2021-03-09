using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
    public interface IPropertiesRepository
    {
        IMongoQueryable<Property> All();
        Property ByName(string name);
        Property Create(Property property);
        IEnumerable<Property> ByKeys(IEnumerable<string> propertyIds);
    }
}
