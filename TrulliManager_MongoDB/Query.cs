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

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Trullo>> GetTrulli([Service] ITrulloRepository trulloRepository)
        {
            List<Trullo> trulli = new List<Trullo>();

            await Task.Run(() =>
            {
                trulli = trulloRepository.GetAll().ToList();
            });

            return trulli;
        }

        public async Task<Trullo> GetTrulloById([Service] ITrulloRepository trulloRepository, [Service] ITopicEventSender eventSender, string id)
        {
            Trullo trulloResult = trulloRepository.GetTrulloById(id);
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
