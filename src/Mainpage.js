import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import Carousel from 'react-bootstrap/Carousel';
import { BrowserRouter, Routes , Route, Link, Navigate } from 'react-router-dom';

function MainPage() {
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

    <Carousel id="slideCarousel" style={{ maxHeight: "913px", height: "100%" }}>
      <Carousel.Item>
        <img
          className="d-block w-100 "
          src={require('./images/cpu.png')}
          alt="First slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />
        <Carousel.Caption>
          <h3>Processzorok</h3>
          <p>Webshopunk a legmodernebb, legjobb Processzorokkat kínálja eladásra a legkedvezőbb áron. Legyen szó játékról, számítógépes munkáról, vagy szerverekről. Nálunk 
            megtalálja amit keres.
          </p>
        </Carousel.Caption>
      </Carousel.Item>

      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/rtx.png')}
          alt="Second slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />

        <Carousel.Caption>
          <h3>Videókártyák</h3>
          <p>Válasszon Videókártyáink széles választékából, nálunk minden célra, legyen az játék, vagy grafikai munka, vagy bányászat, megtalálja amit keres.</p>
        </Carousel.Caption>
      </Carousel.Item>

      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/ram.png')}
          alt="Third slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />

        <Carousel.Caption>
          <h3>RAM-ok</h3>
          <p>
            Számítógépe sebességének növeléséhez több memóriára lenne szüksége? Ne aggódjon! Nálunk erre is talál megoldást. A leggyorsabb memória modulok széles tárházát 
            kínáljuk Önnek. 
          </p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/motherb.png')}
          alt="Fourth slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />

        <Carousel.Caption>
          <h3>Alaplapok.</h3>
          <p>
            Mindennek az alapja a legfontosabb. Válassza ki nálunk számítógépének szívét-lelkét legminőségibb alaplapjaink óriási választékából, legyen Inteles vagy AMD-s 
            processzora, nálunk mindkettőhöz talál megoldást.
          </p>
        </Carousel.Caption>
      </Carousel.Item>

      <Carousel.Item>
        <img
          className="d-block w-100 h-100"
          src={require('./images/psu.png')}
          alt="Fifth slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />

        <Carousel.Caption>
          <h3>Tápegységek</h3>
          <p>
            Mire jó egy számítógép áram nélkül? Válassza meg bölcsen a tápegységét, remek besorolású tápegységeink garantáltan nem lesznek zárlatosak, és nem fognak 
            csalódást okozni. 
          </p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/case.png')}
          alt="Sixth slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />

        <Carousel.Caption>
          <h3>Számítógépházak</h3>
          <p>
            Van, akinek a stílus sem utolsó szempont, és van, aki az egyszerűséget kedveli. Nálunk mindkét oldalról talál megoldást. RGB-s, sima fekete, és 
            egyéb más számítógépházaink közül választhatja ki az önnek legmegfelelőbbet, hogy Számítógépe a lehető legjobban nézhessen ki, és még jól is szellőzzön. 
          </p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item>
        <img
          className="d-block w-100"
          src={require('./images/cooling.png')}
          alt="Fifth slide"
          style={{ objectFit: "cover", maxHeight: "913px", height: "100%", width: "100%" }}
        />

        <Carousel.Caption>
          <h3>Hűtések</h3>
          <p>
            Akármilyen jól is építette meg számítógépét, nem sokat ér, ha percek alatt túlmelegszik. De ne aggódjon! Nálunk erre is talál megoldást. 
            Legyen szó lég, vagy akár vízhűtésről, mi mindenre kínálunk megoldást, méghozzá kedvező áron.
          </p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
    
    </div>
    
  );
}

export default MainPage;
