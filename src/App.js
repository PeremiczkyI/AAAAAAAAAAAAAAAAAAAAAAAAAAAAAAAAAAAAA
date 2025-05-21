import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Navbar from './Navbar'
import Home from './Home'
import Players from './Players'
import SinglePlayer from './SinglePlayer'
import NewPlayer from './NewPlayer'

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Navbar/>
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/jatekosok' element={<Players />} />
          <Route path='/jatekos/:id' element={<SinglePlayer />} />
          <Route path='/ujjatekos' element={<NewPlayer />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
