using GreenDonut;
using HotChocolate.Types;
using HotChocolate.Resolvers;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;
using System.Threading.Tasks;
using TrulliManager_MongoDB.DataLoaders;
using System.Threading;
using System.Linq;

namespace TrulliManager_MongoDB.Types
{
    public class TrulloType: ObjectType<Trullo>
    {
        protected override void Configure(IObjectTypeDescriptor<Trullo> descriptor)
        {
            descriptor.Field(a => a._id).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.Description).Type<StringType>();
            descriptor.Field(a => a.Capacity).Type<IntType>();
            descriptor.Field(a => a.Price).Type<FloatType>();
            descriptor.Field(a => a.Property_id).Type<IdType>();

            descriptor
            .Field(p => p.Property)
            .ResolveWith<TrulloResolver>(t => t.GetPropertyAsync(default!, default!, default!));
        }

        private class TrulloResolver
        {
            public async Task<Property> GetPropertyAsync(
                Trullo trullo,
                PropertyDataLoader dataLoader,
                CancellationToken cancellationToken)
            {
                var data = await dataLoader.LoadAsync(new string[] { trullo.Property_id }, cancellationToken);
                return data.FirstOrDefault();
            }
        }
    }
}