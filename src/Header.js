import React, { Component } from "react";
import logo from './images/logoasd.png'

function Header() {
  return (
    <header>
      <img className="img" src={logo} alt="My Image" style={{width:"200px" , height:"200px" , display: "block", margin: "auto"}}/>
    </header>
  );
}

export default Header;