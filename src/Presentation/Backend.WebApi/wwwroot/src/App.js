import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './components/login/login';
import HomePage from './HomePage';
import Reg from './components/reg/reg';
import User from './components/user/user';
import Myprofile from './components/myprofile/myprofile';
import Myresult from './components/myresult/myresult';
import Mycomp from './components/mycomp/mycomp';
import UserManage from './components/usermanage/usermanage';
import Championships from './components/championships/champs';







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
          <Route path="/comp" element={<Mycomp />} />
          <Route path="/usermanage" element={<UserManage />} />
          <Route path="/championships" element={<Championships />} />
        </Routes>
      </Router>
    </div>
    
  )
    
}

export default App;
