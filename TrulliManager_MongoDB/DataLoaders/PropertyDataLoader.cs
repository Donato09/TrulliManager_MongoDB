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
  public class PropertyDataLoader : BatchDataLoader<string, Property>
  {
    private readonly IPropertiesRepository _propertyRepository;

    public PropertyDataLoader(IBatchScheduler batchScheduler, IPropertiesRepository propertyRepository)
        : base(batchScheduler)
    {
      _propertyRepository = propertyRepository;
    }

    protected override async Task<IReadOnlyDictionary<string, Property>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
      return _propertyRepository.All().Where(x => keys.Contains(x._id)).ToDictionary(t => t._id);
    }
  }
}