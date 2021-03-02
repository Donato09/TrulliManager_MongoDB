import { gql } from "@apollo/client";

export const CREATE_PROPERTY_MUTATION = gql`
  mutation CreatePropertyInput(
    $name: String!
    $city: String!
    $street: String!
    $spa: Boolean!
    $swimmingPool: Boolean!
  ) {
    CreatePropertyInput(
        name: $name
        city: $city
        street: $street
        spa: $spa
        swimmingPool: $swimmingPool
    ) {
      id
    }
  }
`;