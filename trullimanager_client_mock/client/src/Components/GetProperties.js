import React, { useEffect, useState } from "react";
import { useQuery, gql } from "@apollo/client";
import { LOAD_PROPERTIES } from "../GraphQL/Queries";

function GetProperties() {
  const { error, loading, data } = useQuery(LOAD_PROPERTIES);
  const [properties, setProperties] = useState([]);
  useEffect(() => {
    if (data) {
      setProperties(data.GetProperties);
    }
  }, [data]);

  return (
    <div>
      {properties.map((item) => {
        return (
          <li key={item._id}>
            {item._id} - {item.name} - {item.city} - {item.street}
          </li>
        )
      })}
    </div>
  );
}

export default GetProperties;
