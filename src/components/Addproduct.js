import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import axios from 'axios';
import { BrowserRouter, Routes , Route, Link, Navigate } from 'react-router-dom';

import { useState } from "react";
import { Button, Offcanvas, Nav } from "react-bootstrap";
import { FaShoppingCart, FaUser } from "react-icons/fa";

function Addproduct() {
  
  const [showCart, setShowCart] = useState(false);
  const [showProfile, setShowProfile] = useState(false);

  const handleClose = (type) => {
    if (type === "cart") {
      setShowCart(false);
    } else if (type === "profile") {
      setShowProfile(false);
    }
  };

  const defaultFormFields = {
    id: "",
    name: "",
    description: "",
    price: "",
    stock: "",
  };

    const [formFields, setFormFields] = useState(defaultFormFields);
    const { id, name, description, price, stock } = formFields;
  
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
        await axios.post('https://localhost:7289/api/Operator/AddProduct', formFields)
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

  const handleShow = (type) => {
    if (type === "cart") {
      setShowCart(true);
    } else if (type === "profile") {
      setShowProfile(true);
    }
  };

  return (
    <div style={{backgroundImage: `url(${require('../images/hatter.jpg')})`,height: '100%' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
    <Navbar style={{backgroundColor: "#36bbe3"}} expand="lg">
      <Container fluid >
        <Navbar.Brand>CyberBuild</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="me-auto my-2 my-lg-0"
            style={{ maxHeight: '100px' }}
            navbarScroll
          >
            <Nav.Link href="/mainpage">Home</Nav.Link>
          </Nav>
          
        </Navbar.Collapse>
      </Container>
    </Navbar>

    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
      <h1 className='asd' style={{marginBottom:'30px'}}>Termék hozzáadás</h1>
      <form onSubmit={handleSubmit} className="asd">
        <label className='asd2' htmlFor="name">Termék neve</label>
        <input className='asd2' placeholder="NVIDIA GeForce RTX 3060Ti" id="name" onChange={handleChange} name="name" value={name} style={{width:'250px' , height:'20px'}} />
       
        <label className='asd2' htmlFor="email">Termék leírás</label>
        <input className='asd2' placeholder="leírás" id="email" onChange={handleChange} name="description" value={description} style={{width:'250px' , height:'20px'}} />
       
        <label className='asd2' htmlFor="password">Ára</label>
        <input className='asd2' placeholder="999999 FT" id="password" onChange={handleChange} name="price" value={price} style={{width:'250px' , height:'20px'}}/>
       
        <label className='asd2' htmlFor="repeatPassword">Mennyiség</label>
        <input className='asd2' placeholder="X db" id="repeatPassword" onChange={handleChange} name="stock" value={stock}  style={{width:'250px' , height:'20px'}}/>
       
        <button type="submit" style={{marginTop:'15px'}}>Hozzáad!</button>
      </form>
    </div>

    </div>
    
  );
}

export default Addproduct;
