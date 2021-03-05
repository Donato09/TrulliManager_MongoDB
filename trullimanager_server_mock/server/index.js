const { importSchema } = require('graphql-import');
const { ApolloServer, MockList } = require('apollo-server');

var casual = require('casual');
const PORT = 4000;
const typeDefs = importSchema ('./schema/myschema.graphql');


const mocks = {
    Trullo: () => ({
        _id: casual.uuid,
        property_id: casual.uuid,
        name: 'Trullo ' + casual.title,
        description: casual.description,
        capacity: casual.integer,
        price: casual.double
    }),
    Property: () => ({
        _id: casual.uuid,
        name: 'Property ' + casual.title,
        city: casual.city,
        street: casual.street,
        spa: casual.boolean,
        swimmingPool: casual.boolean,
        trulli: MockList(3)
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