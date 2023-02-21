import React from 'react';
import { Link } from 'react-router-dom';
import Header from './Header'; 
import './App.css';

function Register() {
  
  const handleSubmit = (event) => {
  
    event.preventDefault();
    const data = new FormData(event.target);
  
    fetch('/api/register', {
      method: 'POST',
      body: data
    })
  
    .then(response => {
        // Handle successful response
    })
  
    .catch(error => {
      // Handle error
    });
  };

  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
      <h1 className='asd' style={{marginBottom:'30px'}}>Register</h1>
      <form onSubmit={handleSubmit} className="asd">
        <label className='asd2' htmlFor="email">email</label>
        <input className='asd2' placeholder="youremail@gmail.com" id="email" name="email" style={{width:'250px' , height:'20px'}}/>
        <label className='asd2' htmlFor="password">password</label>
        <input className='asd2' type="password" placeholder="Password" id="password" name="password" style={{width:'250px' , height:'20px'}}/>
        <label className='asd2' htmlFor="password">repeat password</label>
        <input className='asd2' type="password" placeholder="Repeat Password" id="password" name="password" style={{width:'250px' , height:'20px'}}/>
        <button type="submit" style={{marginTop:'15px'}}>Register</button>
        <Link to='/login' style={{marginTop:'30px'}}>Already have an Account? Why don't you log in?</Link>
      </form>
    </div>
  );
}

export default Register;