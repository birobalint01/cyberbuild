import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Header from './Header'; 
import './App.css';
import axios from 'axios';

const defaultFormFields = {
  name: "",
  email: "",
  password: "",
  passwordConfirmation: ""
};

function Register() {
  const [formFields, setFormFields] = useState(defaultFormFields);
  const { name, email, password, passwordConfirmation } = formFields;

  const handleChange = (event) => {
    const { name, value } = event.target;

    setFormFields((prev) => {
      return {
        ...prev,
        [name]: value
      }
    })
  }

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await axios.post('https://localhost:7289/v1/api/Auth/Registration', formFields)
        .then(response =>{
          console.log(response);

          if (response.status == 200) {
            setFormFields(defaultFormFields);
          }
        })
        .catch(error =>{
          if (error?.response?.data?.message) {
            alert(error?.response?.data?.message)
          } else {
            alert(error.message)
          }
          setFormFields(defaultFormFields);
        })
    } catch (e) {
      console.error(e);
      setFormFields(defaultFormFields);
    }
  }

  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
      <h1 className='asd' style={{marginBottom:'30px'}}>Register</h1>
      <form onSubmit={handleSubmit} className="asd">
        <label className='asd2' htmlFor="name">name</label>
        <input className='asd2' placeholder="Pelda Janos" id="name" onChange={handleChange} name="name" value={name} style={{width:'250px' , height:'20px'}} />
       
        <label className='asd2' htmlFor="email">email</label>
        <input className='asd2' placeholder="youremail@gmail.com" id="email" onChange={handleChange} name="email" value={email} style={{width:'250px' , height:'20px'}} />
       
        <label className='asd2' htmlFor="password">password</label>
        <input className='asd2' type="password" placeholder="Password" id="password" onChange={handleChange} name="password" value={password} style={{width:'250px' , height:'20px'}}/>
       
        <label className='asd2' htmlFor="repeatPassword">repeat password</label>
        <input className='asd2' type="password" placeholder="Repeat Password" id="repeatPassword" onChange={handleChange} name="passwordConfirmation" value={passwordConfirmation}  style={{width:'250px' , height:'20px'}}/>
       
        <button type="submit" style={{marginTop:'15px'}}>Register</button>
        <Link to='/login' style={{marginTop:'30px'}}>Already have an Account? Why don't you log in?</Link>
      </form>
    </div>
  );
}

export default Register;