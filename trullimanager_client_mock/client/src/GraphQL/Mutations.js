import { gql } from "@apollo/client";

export const CREATE_PROPERTY_MUTATION = gql`
  mutation (
    $inputType: CreatePropertyInput
    ) {
    createProperty (
        property: $inputType
    ) {
      _id
    }
  }
`;

// $name: String
// $city: String
// $street: String
// $spa: Boolean!
// $swimmingPool: Boolean!

// name: $name
//         city: $city
//         street: $street
//         spa: $spa
//         swimmingPool: $swimmingPool