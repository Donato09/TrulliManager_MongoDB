
using HotChocolate.Types;
using TrulliManager.Database.Models;
using TrulliManager.Repository.Abstract;

namespace TrulliManager_MongoDB.Types
{
    public class PropertyType: ObjectType<Property>
    {
        protected override void Configure(IObjectTypeDescriptor<Property> descriptor)
        {
            descriptor.Field(a => a._id).Type<NonNullType<IdType>>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.City).Type<StringType>();
            descriptor.Field(a => a.Street).Type<StringType>();
            descriptor.Field(a => a.Spa).Type<BooleanType>();
            descriptor.Field(a => a.SwimmingPool).Type<BooleanType>();
        }
    }

}
