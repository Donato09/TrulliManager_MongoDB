import { gql } from "@apollo/client";

export const LOAD_PROPERTIES = gql`
  query {
  properties {
    nodes {
      _id,
      city,
      name,
      trulli {
        _id,
        name
      }
    }
  }
}
`;
