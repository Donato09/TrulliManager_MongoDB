import React, { useState } from "react";
import { CREATE_PROPERTY_MUTATION } from "../GraphQL/Mutations";
import { useMutation } from "@apollo/client";

function Form() {
  const [name, setName] = useState("");
  const [city, setCity] = useState("");
  const [street, setStreet] = useState("");
  const [spa, setSpa] = useState("");
  const [swimmingPool, setSwimmingPool] = useState("");

  const [createProperty, { error }] = useMutation(CREATE_PROPERTY_MUTATION);

  const addProperty = () => {
    createProperty({
      variables: {
        name: name,
        city: city,
        street: street,
        spa: spa,
        swimmingPool: swimmingPool
      },
    });

    if (error) {
      console.log(error);
    }
  };
  return (
    <div>
      <input
        type="text"
        placeholder="Name"
        onChange={(e) => {
          setName(e.target.value);
        }}
      />
      <input
        type="text"
        placeholder="City"
        onChange={(e) => {
          setCity(e.target.value);
        }}
      />
      <input
        type="text"
        placeholder="Street"
        onChange={(e) => {
          setStreet(e.target.value);
        }}
      />
      <input
        type="checkbox"
        placeholder="Spa"
        onChange={(e) => {
          setSpa(e.target.value);
        }}
      />
      <input
        type="checkbox"
        placeholder="Swimming Pool"
        onChange={(e) => {
          setSwimmingPool(e.target.value);
        }}
      />
      <button onClick={addProperty}> Create Property</button>
    </div>
  );
}

export default Form;
