import React, { Component } from "react";
import logo from './images/logo.png'

function Header() {
  return (
    <header>
      <img className="img" src={logo} alt="My Image" style={{ maxWidth:'250px', maxHeight: '200px', display: "block", margin: "auto"}}/>
    </header>
  );
}

export default Header;