import React, { useEffect, useState } from "react";
import { useQuery, gql } from "@apollo/client";
import { LOAD_PROPERTIES } from "../GraphQL/Queries";

function GetProperties() {
  const { error, loading, data } = useQuery(LOAD_PROPERTIES);
  const [properties, setProperties] = useState([]);
  useEffect(() => {
    if (data) {
      setProperties(data.properties.nodes);
    }
  }, [data]);

  return (
    <div>
      {properties.map((item) => {
        return (
          <li key={item._id}>
            Property - {item._id} - {item.name} - {item.city} 
            
            {item.trulli.map((trulli) => {
              return (
              <li key={trulli._id}>
                Trullo - {trulli._id} - {trulli.name}
                <br></br>
              </li> 
              )
            })}
            <br></br>
          </li>
        )
      })}
    </div>
  );
}

export default GetProperties;
