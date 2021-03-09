using GreenDonut;
using HotChocolate.Types;
using HotChocolate.Resolvers;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;
using System.Threading.Tasks;
using TrulliManager_MongoDB.DataLoaders;
using System.Threading;
using System.Linq;
using System;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using HotChocolate;
using HotChocolate.Data;

namespace TrulliManager_MongoDB.Types
{
  public class TrulloType : ObjectType<Trullo>
  {
    protected override void Configure(IObjectTypeDescriptor<Trullo> descriptor)
    {
      descriptor.Field(a => a._id).Type<NonNullType<IdType>>();
      descriptor.Field(a => a.Name).Type<StringType>();
      descriptor.Field(a => a.Description).Type<StringType>();
      descriptor.Field(a => a.Capacity).Type<IntType>();
      descriptor.Field(a => a.Price).Type<FloatType>();
      descriptor.Field(a => a.Property_id).Type<IdType>();
      descriptor.Include<TrulloResolver>();
      descriptor.Field("properties").ResolveWith<TrulloResolver>(t => t.GetProperties(default!, default!, default!)).Type<ListType<NonNullType<PropertyType>>>().UseFiltering();
      descriptor.Field("property").ResolveWith<TrulloResolver>(t => t.GetProperty(default!, default!, default!));
      //descriptor.Field("property").ResolveWith<TrulloResolver>(t => t.GetProperty(default!, default!, default!)).UseDataloader<PropertyDataLoader>().UseFiltering<Property>();
    }
  }

  //public class Query
  //{
  //  public async Task<IMongoQueryable<Trullo>> GetTrulli([Service] ITrulliRepository repository) => await repository.All();
  //}

  public class TrulloResolver
  {
    [UseFiltering]
    public async Task<IReadOnlyList<Property>> GetProperties(Trullo trullo, PropertyDataLoader dataLoader, CancellationToken cancellationToken)
    {
      var result = await dataLoader.LoadAsync(cancellationToken);
      return result;
    }

    [UseFiltering]
    public async Task<Property> GetProperty(Trullo trullo, PropertyDataLoader dataLoader, CancellationToken cancellationToken)
    {
      if (trullo.Property_id != null)
      {
        return await dataLoader.LoadAsync(trullo.Property_id, cancellationToken);
      }
      return null;
    }
    //public Property GetProperty()
    //{
    //  return new Property { _id = Guid.NewGuid().ToString(), Name = "Pippo" };
    //  //var data = dataLoader.LoadAsync(new string[] { trullo.Property_id }, cancellationToken).Result;
    //  //return data.FirstOrDefault();
    //}
  }
}