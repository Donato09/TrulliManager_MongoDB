const { importSchema } = require('graphql-import');
const { ApolloServer, MockList } = require('apollo-server');

var casual = require('casual');
const PORT = 4000;
const typeDefs = importSchema ('./schema/myschema.graphql');


const mocks = {
    Trullo: () => ({
        _id: casual.uuid,
        property_id: casual.uuid,
        name: casual.name,
        description: casual.description,
        capacity: casual.integer,
        price: casual.double
    }),
    Property: () => ({
        _id: casual.uuid,
        name: casual.name,
        city: casual.city,
        street: casual.street,
        spa: casual.boolean,
        swimmingPool: casual.boolean,
        trulli: MockList(2)
    })
  };

  // The ApolloServer constructor requires two parameters: your schema
// definition and your set of resolvers.
 const apolloServer  = new ApolloServer({ 
     typeDefs,
     mocks
});

apolloServer.listen().then(({ url }) => {
  console.log(`🚀 Server ready at ${url}`)
});