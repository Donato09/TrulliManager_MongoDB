import { gql } from "@apollo/client";

export const LOAD_TRULLI = gql`
  query {
  trulli {
    nodes {
      _id,
      name,
      price,
      capacity,
      property_id
      property {
        _id,
        name,
      }
    }
  }
}
`;
