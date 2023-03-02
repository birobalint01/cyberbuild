import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { BrowserRouter, Routes , Route, Link, Navigate } from 'react-router-dom';

import { useState } from "react";
import { Button, Offcanvas, Nav } from "react-bootstrap";
import { FaShoppingCart, FaUser } from "react-icons/fa";

function Cases() {
  
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
            <Nav.Link href="/mainpage">Home</Nav.Link>
            <Nav.Link href="/faqs">FAQs</Nav.Link>
            <NavDropdown className='dropdown-item' title="Products" id="navbarScrollingDropdown" style={{backgroundColor: '#36bbe3'}}>
              <NavDropdown.Item href="/cpus" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                CPU
              </NavDropdown.Item>
              <NavDropdown.Item href="/gpus" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                GPU
              </NavDropdown.Item>
              <NavDropdown.Item href="/rams" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                RAM
              </NavDropdown.Item>
              <NavDropdown.Item href="/motherbs" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                Motherboard
              </NavDropdown.Item>
              <NavDropdown.Item href="/psus" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                Power Supply
              </NavDropdown.Item>
              <NavDropdown.Item href="/coolings" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                Cooling
              </NavDropdown.Item>
              <NavDropdown.Item href="/cases" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                PC Case
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Form className="d-flex">
            <Form.Control
              type="search"
              placeholder="Search"
              className="me-2"
              aria-label="Search"
            />
            <Button variant="outline-success">Search</Button>
          </Form>
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

    

    </div>
    
  );
}

export default Cases;
