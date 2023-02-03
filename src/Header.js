function Header() {
  return (
    <header style={{backgroundImage: `url(${require('./images/header.jpg')})`, backgroundRepeat: 'no-repeat', backgroundSize: 'cover', padding: "20px" }}>
      <h1 className='cb'>CyberBuild</h1>
    </header>
  );
}

export default Header;