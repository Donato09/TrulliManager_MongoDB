import React, { useEffect, useState } from "react";
import { useQuery, gql } from "@apollo/client";
import { LOAD_TRULLI } from "../GraphQL/Queries";

function GetTrulli() {
  const { error, loading, data } = useQuery(LOAD_TRULLI);
  const [trulli, setTrulli] = useState([]);

  useEffect(() => { //React ricorderà la funzione che hai passato (la chiameremo il nostro "effetto") e 
                    //la richiamerà in seguito dopo aver eseguito gli aggiornamenti DOM.
    if (data) {
      setTrulli(data.trulli.nodes);
    }

  }, [data]);

  return (
    <div>
      {trulli.map((item) => {
        return (
          <li key={item._id}>
            Trullo - {item._id} - {item.name} - {item.price} - {item.capacity} 
            

              <li key={item.property._id}>
                Property - {item.property._id} - {item.property.name}
                <br></br>
              </li> 
            <br></br>
          </li>
        )
      })}
    </div>
  );
}

export default GetTrulli;
