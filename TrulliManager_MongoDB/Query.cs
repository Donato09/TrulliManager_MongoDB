using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager_MongoDB
{
    //public class QueryType: ObjectType<Query>
    //{
    //    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    //    {
    //        descriptor.Field(t => t.GetProperties(default)).UseProjection();
    //        descriptor.Field(t => t.GetTrulli(default)).UseProjection();
    //    }
    //}

    public class Query
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ITrulloRepository _trulloRepository;

        public Query(IPropertyRepository propertyRepository, ITrulloRepository trulloRepository)
        {
            _propertyRepository = propertyRepository;
            _trulloRepository = trulloRepository;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IMongoQueryable<Property> GetProperties([Service] IPropertyRepository repository) => 
            repository.GetAll();
        
        //public IMongoQueryable<Property> Properties => _propertyRepository.GetAll();

        public async Task<Trullo> GetTrulloById([Service] ITrulloRepository trulloRepository, [Service] ITopicEventSender eventSender, string id)
        {
            Trullo trulloResult = trulloRepository.GetTrulloById(id);
            await eventSender.SendAsync("ReturnedTrullo", trulloResult);

            return trulloResult;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IMongoQueryable<Trullo> GetTrulli([Service] ITrulloRepository repository) => 
            repository.GetAll();

        //public IMongoQueryable<Trullo> Trulli => _trulloRepository.GetAll();
    }
}
