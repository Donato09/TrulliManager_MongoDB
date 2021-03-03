using HotChocolate.Types;
using TrulliManager.Database.Models;

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
        }
    }

}