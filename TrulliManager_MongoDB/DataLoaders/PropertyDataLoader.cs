using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;
using System;
using HotChocolate.DataLoader;

namespace TrulliManager_MongoDB.DataLoaders
{
    public class PropertyDataLoader: BatchDataLoader<string, Property>
    {
        private readonly IPropertyRepository _propertyRepository;
        
        public PropertyDataLoader(
            IBatchScheduler batchScheduler,
            IPropertyRepository propertyRepository)
            : base(batchScheduler)
        { 
            _propertyRepository = propertyRepository;
        }

        protected override async Task<IReadOnlyDictionary<string, Property>> LoadBatchAsync(
            IReadOnlyList<string> keys,
            CancellationToken cancellationToken)
        {
            List<Property> properties = new List<Property>();

            await Task.Run(() =>
            {
                properties = _propertyRepository.GetPropertiesByIds(keys).ToList();
            });

            return properties.ToDictionary(t => t._id);
        }
    }
}