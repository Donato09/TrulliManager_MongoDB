import React, { useState } from "react";
import { CREATE_TRULLO_MUTATION } from "../GraphQL/Mutations";
import { useMutation } from "@apollo/client";

var _id;

function Form() {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [capacity, setCapacity] = useState("");
  const [price, setPrice] = useState("");
  const [propertyId, setPropertyId] = useState("");

  const [CreateTrulloInput, { loading, error, data: dataResponse }] = useMutation(CREATE_TRULLO_MUTATION, {

    onSuccess: async () => {
 
      console.log(dataResponse);
      //document.getElementById("result").text = dataResponse;
 
    }});

  const addTrullo = () => {
    CreateTrulloInput({
      variables: {
        inputType: {
          name: name,
          description: description,
          capacity: capacity,
          price: price,
          propertyId: propertyId
        }
      },
    });
  };
  
  return (
    <div>
      <div>
        <label>
          Name: 
          <input
            type="text"
            placeholder="Name"
            onChange={(e) => {
              setName(e.target.value);
            }}
          />
        </label>
        <label>
          Description:
          <input
            type="text"
            placeholder="Description"
            onChange={(e) => {
              setDescription(e.target.value);
            }}
          />
        </label>
        <label>
          Capacity:
          <input
            type="text"
            placeholder="Capacity"
            onChange={(e) => {
              setCapacity(Number(e.target.value));
            }}
          />
        </label>
        <label>
          Price:
          <input
            type="text"
            onChange={(e) => {
              setPrice(Number(e.target.value));
            }}
          />
        </label>
        <label>
          PropertyId:
          <input
            type="text"
            onChange={(e) => {
              setPropertyId(e.target.value);
            }}
          />
        </label>
        <button onClick={addTrullo}> Create Trullo</button>
      </div>

      {loading && <p>Loading...</p>}
      {error && <p>Error :( Please try again</p>}

      { dataResponse != undefined &&
          <p>Result -- {dataResponse.createTrullo._id}</p>
      } 

    </div>
  );   
    
}

export default Form;
