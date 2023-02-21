import React from 'react';
import { Link } from 'react-router-dom';
import Header from './Header'; 
import './App.css';

function Login() {
  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
      <Header></Header>
      <h1 className='asd' style={{marginBottom:'30px'}}>Login</h1>
      <form className="asd">
        <label className='asd2' htmlFor="email">email</label>
        <input className='asd2' placeholder="youremail@gmail.com" id="email" name="email" style={{width:'250px' , height:'20px'}}/>
        <label className='asd2' htmlFor="password">password</label>
        <input className='asd2' type="password" placeholder="********" id="password" name="password" style={{width:'250px' , height:'20px'}}/>
        <button className='asd1' type="submit" style={{marginTop:'15px'}}>Log In</button>
        <Link to='/register' style={{marginTop:'30px'}}>Don't have an account? Register here.</Link>
      </form>
    </div>
  );
}

export default Login;