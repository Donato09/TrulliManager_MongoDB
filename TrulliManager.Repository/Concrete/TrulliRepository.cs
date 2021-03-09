using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrulliManager.Database;
using TrulliManager.Database.CustomException;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager.Repository.Concrete
{
  public class TrulliRepository : ITrulliRepository
  {
    private readonly TrulliContext _db;

    public TrulliRepository(TrulliContext db)
    {
      _db = db;
    }

    public IMongoQueryable<Trullo> GetAll()
    {
      return _db.Trulli.AsQueryable();
    }

    public Trullo ByKey(string id)
    {
      var trullo = _db.Trulli.AsQueryable()
          .Where(t => t._id == id)
          .FirstOrDefault();

      //include property

      return trullo;
    }

    public Trullo Remove(Trullo trullo)
    {
      //var trulloToDelete = GetAll().FirstOrDefault(t => t.Trullo_id == trullo.Trullo_id);
      //if (trulloToDelete == null)
      //    throw new TrulloNotFound() { TrulloId = trullo.Trullo_id };

      //_db.Trulli.FindOneAndDelete(trulloToDelete);

      var filter = new BsonDocument("FirstName", "Jack");

      var result = _db.Trulli.FindOneAndDelete(filter);

      if (result == null)
      {
        throw new TrulloNotFound() { TrulloId = trullo._id };
      }

      return result;
    }

    public async Task<Trullo> Create(Trullo trullo)
    {
      await _db.Trulli.InsertOneAsync(trullo);

      return trullo;
    }

    async Task<IMongoQueryable<Trullo>> ITrulliRepository.All()
    {
      return _db.Trulli.AsQueryable();
    }
  }
}
