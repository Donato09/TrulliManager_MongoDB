using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TrulliManager.Database.Models;

namespace TrulliManager.Database
{
    public class TrulliContext
    {
        private readonly IMongoDatabase _db = null;

        public TrulliContext(ITrulliManagerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);

            if (client != null)
                _db = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<Trullo> Trulli
        {
            get
            {
                return _db.GetCollection<Trullo>("Trulli");
            }
        }

        public IMongoCollection<Property> Properties
        {
            get
            {
                return _db.GetCollection<Property>("Properties");
            }
        }
    }
}
