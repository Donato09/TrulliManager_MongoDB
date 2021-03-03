import React, { useState } from "react";
import { CREATE_PROPERTY_MUTATION } from "../GraphQL/Mutations";
import { useMutation } from "@apollo/client";

var _id;

function Form() {
  const [name, setName] = useState("");
  const [city, setCity] = useState("");
  const [street, setStreet] = useState("");
  const [spa, setSpa] = useState("");
  const [swimmingPool, setSwimmingPool] = useState("");

  const [CreatePropertyInput, { loading, error, data: dataResponse }] = useMutation(CREATE_PROPERTY_MUTATION, {

    onSuccess: async () => {
 
      console.log(dataResponse);
      document.getElementById("result").text = dataResponse;
 
    }});

  const addProperty = () => {
    CreatePropertyInput({
      variables: {
        inputType: {
          name: name,
          city: city,
          street: street,
          spa: true,
          swimmingPool: false
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
          City:
          <input
            type="text"
            placeholder="City"
            onChange={(e) => {
              setCity(e.target.value);
            }}
          />
        </label>
        <label>
          Street:
          <input
            type="text"
            placeholder="Street"
            onChange={(e) => {
              setStreet(e.target.value);
            }}
          />
        </label>
        <label>
          SPA:
          <input
            type="checkbox"
            onChange={(e) => {
              setSpa(e.target.value);
            }}
          />
        </label>
        <label>
          Swimming Pool:
          <input
            type="checkbox"
            onChange={(e) => {
              setSwimmingPool(e.target.value);
            }}
          />
        </label>
        <button onClick={addProperty}> Create Property</button>
      </div>

      {loading && <p>Loading...</p>}
      {error && <p>Error :( Please try again</p>}

      { dataResponse != undefined &&
          <p>Result -- {dataResponse.createProperty._id}</p>
      } 

      <div id="result"></div>
    </div>
  );   
    
}

export default Form;
