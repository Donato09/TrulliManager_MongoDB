import "./App.css";
import {
  ApolloClient,
  InMemoryCache,
  ApolloProvider,
  HttpLink,
  from,
} from "@apollo/client";
import { onError } from "@apollo/client/link/error";
import GetProperties from "./Components/GetTrulli";
import Form from "./Components/Form";

const errorLink = onError(({ graphqlErrors, networkError }) => {
  if (graphqlErrors) {
    graphqlErrors.map(({ message, location, path }) => {
      alert(`Graphql error ${message}`);
    });
  }
});

//const httplink = new HttpLink({ uri: "http://localhost:4000/graphql" })
const httplink = new HttpLink({ uri: "http://localhost:5000/graphql" })

const link = from([
  errorLink,
  httplink,
]);

const client = new ApolloClient({
  cache: new InMemoryCache(),
  link: link,
});

function App() {
  return (
    <ApolloProvider client={client}>
      {" "}
      <GetProperties />
      <Form />
    </ApolloProvider>
  );
}

export default App;
