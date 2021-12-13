import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './index.css';



import Home from './Pages/Home/App.js';
import Login from './Pages/Login/Login';
import ListarMedico from './Pages/ListarMedico/ListarMedico';


import reportWebVitals from './reportWebVitals';


const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/"component={Home}/>
        <Route exact path="/Login"component={Login}/>
        <Route exact path="/ListarMeidico"component={ListarMedico}/>
      </Switch>
    </div>
  </Router>


);
ReactDOM.render(
  routing,
  document.getElementById('root')
);
  

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
