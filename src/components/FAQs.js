import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { BrowserRouter, Routes , Route, Link, Navigate } from 'react-router-dom';

function FAQs() {
  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`,height: '100%' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
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
            <Nav.Link href="#">Home</Nav.Link>
            <Nav.Link href="#action2">FAQs</Nav.Link>
            <NavDropdown className='dropdown-item' title="Products" id="navbarScrollingDropdown" style={{backgroundColor: '#36bbe3'}}>
              <NavDropdown.Item href="#action4" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                CPU
              </NavDropdown.Item>
              <NavDropdown.Item href="#action5" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                GPU
              </NavDropdown.Item>
              <NavDropdown.Item href="#action4" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                RAM
              </NavDropdown.Item>
              <NavDropdown.Item href="#action4" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                Motherboard
              </NavDropdown.Item>
              <NavDropdown.Item href="#action4" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                Power Supply
              </NavDropdown.Item>
              <NavDropdown.Item href="#action4" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
                Cooling
              </NavDropdown.Item>
              <NavDropdown.Item href="#action4" style={{ backgroundColor: '#36bbe3', color: 'black'}}>
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
    </Navbar>

    </div>
    
  );
}

export default FAQs;
