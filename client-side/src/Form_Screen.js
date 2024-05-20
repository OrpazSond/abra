import { useState } from 'react';
import { HexColorPicker, HexColorInput } from "react-colorful";
import { useNavigate } from "react-router-dom";
import './App.css';

function Form_Screen() {
  const [petName, setPetName] = useState('');
  const [petAge, setPetAge] = useState('');
  const [petType, setPetType] = useState('');
  const [petColor, setPetColor] = useState('#aabbcc');
  const [loading, setLoading] = useState(false);
  const types = ['Dog', 'Cat', 'Horse', 'Other'];

  const handlePetName = (event) => {
    setPetName(event.target.value);
  };

  const handlePetAge = (event) => {
    setPetAge(event.target.value);
  };

  const handlePetType = (event) => {
    setPetType(event.target.value);
  };


  const handleSubmit = () => {
    setLoading(true);
    fetch("https://localhost:7210/api/Pet/", {
      method: "POST", 
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(
        {
          name: petName,
          age: petAge,
          type: petType,
          color: petColor
        }
      )
    })
      .then((response) => response.json())
      .then((data) => {
        setLoading(false);
      })
      .catch((error) => console.log(error));
  } ;

  if (loading) return <p>Loading...</p>;

  return (
    <div className="App">
    <h1>Create a new pet:</h1>
    <div>name:</div>
    <input type="text" value={petName} onChange={handlePetName} maxLength='25'/><br></br>
    <div>age:</div>
    <input name="age" type="number" max={20} min={0} onChange={handlePetAge}/>
    <div>type:</div>
    <select  
    onChange={handlePetType}>
    {types.map(type => <option key={type} value={type}>{type}</option>)}
</select>
<div>color:</div>
<HexColorPicker color={petColor} onChange={setPetColor} /><br></br>
      <HexColorInput color={petColor} onChange={setPetColor} /><br></br>
    <button onClick={handleSubmit}>submit</button>
    </div>
  );
}

export default Form_Screen;