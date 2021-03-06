﻿using System.Collections.Generic;
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
    public class PropertyRepository : IPropertyRepository
    {
        private readonly TrulliContext _db;

        public PropertyRepository(TrulliContext db)
        {
            _db = db;
        }

        public IMongoQueryable<Property> GetAll()
        {
            return _db.Properties.AsQueryable();
        }

        public Property GetByName(string name)
        {
            return _db.Properties.Find(document => document.Name.Equals(name)).FirstOrDefault();
        }

        public Property Create(Property property)
        {
            _db.Properties.InsertOne(property);
            return property;
        }

        public IEnumerable<Property> GetPropertiesByIds(IEnumerable<string> propertyIds)
        {
            return _db.Properties.AsQueryable().Where(x => propertyIds.Contains(x._id));
        }

    }
}
