import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { BrowserRouter, Routes , Route, Link, Navigate } from 'react-router-dom';
import Header from '../Header';
import { useState } from "react";
import { Button, Offcanvas, Nav } from "react-bootstrap";
import { FaShoppingCart, FaUser } from "react-icons/fa";

function FAQs() {

  const [showCart, setShowCart] = useState(false);
  const [showProfile, setShowProfile] = useState(false);

  const handleClose = (type) => {
    if (type === "cart") {
      setShowCart(false);
    } else if (type === "profile") {
      setShowProfile(false);
    }
  };

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
            <Nav.Link href="/mainpage" style={{fontWeight : 'bold'}}>Home</Nav.Link>
        </Nav>
        </Navbar.Collapse>
        </Container>
        <Button variant="outline-success" onClick={() => handleShow("cart")}>
              <FaShoppingCart size={20} />
            </Button>
            <Button variant="outline-success ms-2" onClick={() => handleShow("profile")}>
              <FaUser size={20} />
            </Button>
            <Offcanvas show={showCart} onHide={() => handleClose("cart")} placement="end"  style={{ backgroundColor: '#36bbe3', color: 'black'}}> 
              <Offcanvas.Header closeButton>
                <Offcanvas.Title>Shopping Cart</Offcanvas.Title>
              </Offcanvas.Header>
              <Offcanvas.Body>
                {/* Add your shopping cart component here */}
                This is the shopping cart component
              </Offcanvas.Body>
            </Offcanvas>
             <Offcanvas show={showProfile} onHide={() => handleClose("profile")} placement="end"  style={{ backgroundColor: '#36bbe3', color: 'black'}}>
              <Offcanvas.Header closeButton>
                <Offcanvas.Title>User Profile</Offcanvas.Title>
                </Offcanvas.Header>
                <Offcanvas.Body>
                {/* Add your profile component here */}
                This is the Profile component
              </Offcanvas.Body>
            </Offcanvas>
    </Navbar>

    <Header></Header>

    <h2></h2>
    
    
    
    
      <p style={{fontWeight : 'bold'}}>Q: Miről szól az oldalunk?</p>
      <p style={{fontWeight : 'bold'}}>A: Az oldalunk egy számítástechnikai alkatrészekkel foglalkozó oldal, ahol alkatrészenként, 
      vagy akár egyben megépítve várásolhatja meg számítógépét.</p>
      <p style={{fontWeight : 'bold'}}>                                                                                 </p>
      <p style={{fontWeight : 'bold'}}>Q: Miért minket válasszon?</p>
      <p style={{fontWeight : 'bold'}}>A: A piac egyik legkedvezőbb cége vagyunk, 
      és nálunk akár hozzáértés nélkül is megépítheti számítógépét, hisz rendszerünk mindenben asszisztálni fogja.</p>
      
    </div>
    
  );
}

export default FAQs;
