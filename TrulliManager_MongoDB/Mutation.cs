using HotChocolate;
using HotChocolate.Subscriptions;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;
using TrulliManager_MongoDB.ViewModel;

namespace TrulliManager_MongoDB
{
  public class Mutation
  {
    private readonly ITrulliRepository _trulliRepository;
    private readonly IPropertiesRepository _propertiesRepository;

    public Mutation(ITrulliRepository trulloRepository, IPropertiesRepository propertyRepository)
    {
      _trulliRepository = trulloRepository;
      _propertiesRepository = propertyRepository;
    }

    public async Task<Trullo> CreateTrullo([Service] ITrulliRepository trulloRepository, [Service] ITopicEventSender eventSender, CreateTrulloInput trullo)
    {
      Trullo newTrullo = new Trullo
      {
        _id = ObjectId.GenerateNewId().ToString(),
        Name = trullo.Name,
        Description = trullo.Description,
        Capacity = trullo.Capacity,
        Price = trullo.Price,
        Property_id = trullo.PropertyId
      };

      var createdTrullo = await trulloRepository.Create(newTrullo);

      await eventSender.SendAsync("TrulloCreated", createdTrullo);

      return createdTrullo;
    }

    public Trullo DeleteTrullo(DeleteTrulloInput deletedTrullo)
    {
      Trullo oldTrullo = new Trullo
      {
        _id = deletedTrullo.Id
      };

      return _trulliRepository.Remove(oldTrullo);
    }

    public Property CreateProperty(CreatePropertyInput property)
    {
      Property newProperty = new Property
      {
        _id = ObjectId.GenerateNewId().ToString(),
        Name = property.Name,
        City = property.City,
        Street = property.Street,
        Spa = property.Spa,
        SwimmingPool = property.SwimmingPool,
      };

      return _propertiesRepository.Create(newProperty);
    }
  }
}
