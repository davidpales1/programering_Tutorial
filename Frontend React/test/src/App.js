import logo from './logo.svg';
import './App.css';
import Owner from './Owner.js'
let Car = () => {
  return(
    <div><div>Brand: volvo</div><div>Model:1900</div>
            <Owner/>
</div>
    
  );
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        <Car/>
      </header>
    </div>
  );
}

export default App;
