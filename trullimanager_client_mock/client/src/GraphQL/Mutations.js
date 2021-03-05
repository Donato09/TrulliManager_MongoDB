import { gql } from "@apollo/client";

export const CREATE_TRULLO_MUTATION = gql`
  mutation (
    $inputType: CreateTrulloInput
    ) {
    createTrullo (
        trullo: $inputType
    ) {
      _id
    }
  }
`;