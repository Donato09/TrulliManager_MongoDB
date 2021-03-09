using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager_MongoDB
{
  public class Query
  {
    private readonly IPropertiesRepository _propertyRepository;
    private readonly ITrulliRepository _trulloRepository;

    public Query(IPropertiesRepository propertyRepository, ITrulliRepository trulloRepository)
    {
      _propertyRepository = propertyRepository;
      _trulloRepository = trulloRepository;
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IMongoQueryable<Property> GetProperties([Service] IPropertiesRepository repository) =>
        repository.All();

    public IMongoQueryable<Property> Properties => _propertyRepository.All();

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IMongoQueryable<Trullo>> GetTrulli([Service] ITrulliRepository trulloRepository)
    {
      var result = await trulloRepository.All();
      return result;
    }

    public async Task<Trullo> GetTrulloById([Service] ITrulliRepository trulloRepository, [Service] ITopicEventSender eventSender, string id)
    {
      Trullo trulloResult = trulloRepository.ByKey(id);
      await eventSender.SendAsync("ReturnedTrullo", trulloResult);

      return trulloResult;
    }

    // [UsePaging]
    // [UseProjection]
    // [UseFiltering]
    // [UseSorting]
    // public IMongoQueryable<Trullo> GetTrulli([Service] ITrulloRepository repository) => 
    //     repository.GetAll();

    //public IMongoQueryable<Trullo> Trulli => _trulloRepository.GetAll();
  }
}
