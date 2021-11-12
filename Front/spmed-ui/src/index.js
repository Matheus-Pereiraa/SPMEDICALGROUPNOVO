import React from 'react';
import ReactDOM from 'react-dom';


import './index.css';



import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom';




import Login from './Pages/Login/Login.js';
import Home from './Pages/Home/App';
import NotFound from './Pages/NotFound/NotFound';





import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
          <Route exact path="/" component={Home} />{/* Home */}
          <Route path="/login" component={Login} />{/* Login */}
          <Route path="/notfound" component={NotFound} />{/* NotFound */}
          <Redirect to='/notfound' /> {/* NotFound */}
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
