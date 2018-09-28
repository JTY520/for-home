import React from 'react';
import ReactDOM from 'react-dom';
import {Provider} from 'react-redux';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import {Route, Router, Switch} from "react-router";
import createBrowserHistory from "history/createBrowserHistory";
import {store} from './lib';


ReactDOM.render(
    <Provider store={store}>
        <Router  history={createBrowserHistory()}>
          <Switch>
            <Route path="/" component={App}/>
          </Switch>
        </Router>
    </Provider>
    , document.getElementById('root'));
registerServiceWorker();
