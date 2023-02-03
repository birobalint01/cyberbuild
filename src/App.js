import './App.css';
import Header from './Header'; 

function App() {
  return (
    <div style={{backgroundImage: `url(${require('./images/hatter.jpg')})`, height: '100vh'}}>
      <Header></Header>
      <h1 className='asd'>Login</h1>
            <form className="asd">
                <label className='asd2' htmlFor="email">email</label>
                <input className='asd2' placeholder="youremail@gmail.com" id="email" name="email" />
                <label className='asd2' htmlFor="password">password</label>
                <input className='asd2' type="password" placeholder="********" id="password" name="password" />
                <button className='asd2' type="submit">Log In</button>
                <button className="asd2">Don't have an account? Register here.</button>
            </form>
            
    </div>
  );
}

export default App;
