import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import Login from './Pages/Login/Login';
import {Router, BrowseRouter as Router, Switch} from 'react-router-dom';




import Home from './Pages/Home/App';



const routing = (
  <Router>
    <div>
      <Switch>
          <Route exact path="/" component={Home} />{/* Home */}
          <Route path="/Login" Component={Login} />{/* Login */}
      </Switch>
    </div>
  </Router>

)





ReactDOM.render(
  routing, 
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
