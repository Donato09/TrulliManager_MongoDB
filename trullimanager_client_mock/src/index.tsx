import { makeExecutableSchema } from '@graphql-tools/schema';
import { addMocksToSchema } from '@graphql-tools/mock';
import { graphql } from 'graphql';
import { loadSchema } from '@graphql-tools/load'
import { GraphQLFileLoader } from '@graphql-tools/graphql-file-loader'

// Fill this in with the schema string
//const schemaString = `...`;

// Make a GraphQL schema with no resolvers
//const schema = makeExecutableSchema({ typeDefs: schemaString });

const schema = await loadSchema('schema.graphql', {  // load from a single schema file
  loaders: [
      new GraphQLFileLoader()
  ]
});

// Create a new schema with mocks
const schemaWithMocks = addMocksToSchema({ schema });

const query = `
query {  
  properties {    
    nodes {     
      id,      
      name    
    }  
  }
}
`;

graphql(schemaWithMocks, query).then((result) => console.log('Got result', result));