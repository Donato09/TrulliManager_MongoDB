using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using TrulliManager.Database.Models;

namespace TrulliManager.Repository.Abstract
{
    public interface IPropertyRepository
    {
        IMongoQueryable<Property> GetAll();
        Property GetByName(string name);
        Property Create(Property property);
        IEnumerable<Property> GetPropertiesByIds(IEnumerable<string> propertyIds);
    }
}
