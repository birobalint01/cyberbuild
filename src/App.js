import './App.css';
import Header from './Header'; 
import React, { useEffect, useState } from 'react';
import { BrowserRouter, Routes , Route, Link, Navigate } from 'react-router-dom';
import Login from './Login';
import Register from './Register';
import MainPage from './Mainpage';
import FAQs from './components/FAQs';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    if (!isLoggedIn) {
      return <Navigate to="/login" />
    }
  }, [])

  return (
    <BrowserRouter>
      <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/mainpage" element={<MainPage />} />
          <Route path="/faqs" element={<FAQs />} />
          <Route path="*" element={<h1>Not found</h1>} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;