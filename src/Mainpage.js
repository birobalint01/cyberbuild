import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Carousel from 'react-bootstrap/Carousel';

function MainPage() {
  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh' , backgroundRepeat: 'no-repeat' , backgroundSize: 'cover  '}}>
    <Navbar style={{backgroundColor: "#36bbe3"}} expand="lg">
      <Container fluid >
        <Navbar.Brand href="#">CyberBuild</Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="me-auto my-2 my-lg-0"
            style={{ maxHeight: '100px' }}
            navbarScroll
          >
            <Nav.Link href="#action1">Home</Nav.Link>
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
    <Carousel>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/header.jpg')}
          alt="First slide"
          style={{ objectFit: "cover", height: "100%" }}
        />
        <Carousel.Caption>
          <h3>First slide label</h3>
          <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/rtx.png')}
          alt="Second slide"
          style={{ objectFit: "cover", height: "100%" }}
        />

        <Carousel.Caption>
          <h3>Second slide label</h3>
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/rtx.png')}
          alt="Third slide"
          style={{ objectFit: "cover", height: "100%" }}
        />

        <Carousel.Caption>
          <h3>Third slide label</h3>
          <p>
            Praesent commodo cursus magna, vel scelerisque nisl consectetur.
          </p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
    </div>
    
  );
}

export default MainPage;
