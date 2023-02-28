import React from 'react';
import { Link } from 'react-router-dom';
import Header from './Header'; 
import './App.css';

function Login() {
  const login = (e) => {
    e.preventDefault()
    window.location.href = "/mainpage"
  }
  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
      <h1 className='asd' style={{marginBottom:'30px'}}>Login</h1>
      <form className="asd">
        <label className='asd2' htmlFor="email">email</label>
        <input className='asd2' placeholder="youremail@gmail.com" id="email" name="email" style={{width:'250px' , height:'20px'}}/>
        <label className='asd2' htmlFor="password">password</label>
        <input className='asd2' type="password" placeholder="********" id="password" name="password" style={{width:'250px' , height:'20px'}}/>
        <button className='asd1' type="button" style={{marginTop:'15px'}} onClick={login}>Log In</button>
        <Link to='/register' style={{marginTop:'30px'}}>Don't have an account? Register here.</Link>
      </form>
    </div>
  );
}

export default Login;