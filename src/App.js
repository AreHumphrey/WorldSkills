import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './components/login/login';
import HomePage from './HomePage';
import Reg from './components/reg/reg';
import User from './components/user/user';
import Myprofile from './components/myprofile/myprofile';
import Myresult from './components/myresult/myresult';






function App() {
  return (
    <div className="App">
      
      
      <Router>
        <Routes>
          <Route exact path="/" element={<HomePage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/registration" element={<Reg />} />
          <Route path="/user" element={<User />} />
          <Route path="/profile" element={<Myprofile />} />
          <Route path="/result" element={<Myresult />} />
        </Routes>
      </Router>
    </div>
    
  )
    
}

export default App;
