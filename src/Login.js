import React, { useRef } from 'react';
import { useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import './App.css';

function Login() {
  const email = useRef('');
  const password = useRef('');

  const login = (e) => {
    e.preventDefault();
    if (!email.current.value || !password.current.value) {
      alert("Ki kell tölteni az adatokat!")
    }
    axios.post('https://localhost:7289/v1/api/Auth/Login', { "email": email.current.value, "password": password.current.value })
      .then(response => {
        console.log(response);
        window.location.href = "/mainpage";
      })
      .catch(error => {
        // if login fails, display error message to user
        console.error(error);
        alert('Invalid email or password');
      });
  }


  return (
    <div style={{ backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh', backgroundRepeat: 'no-repeat', backgroundSize: 'cover  ' }}>
      <h1 className='asd' style={{ marginBottom: '30px' }}>Login</h1>
      <form className="asd">
        <label className='asd2' htmlFor="email">email</label>
        <input className='asd2' placeholder="youremail@gmail.com" ref={email} id="email" name="email" style={{ width: '250px', height: '20px' }} />
        <label className='asd2' htmlFor="password">password</label>
        <input className='asd2' type="password" ref={password} placeholder="********" id="password" name="password" style={{ width: '250px', height: '20px' }} />
        <button className='asd1' type="button" style={{ marginTop: '15px' }} onClick={login}>Log In</button>
        <Link to='/register' style={{ marginTop: '30px' }}>Don't have an account? Register here.</Link>
      </form>
    </div>
  );
}

export default Login;