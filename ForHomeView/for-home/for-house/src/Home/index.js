import React, { Component } from 'react';
import Broadcast from './broadcast'
import Recommand from './recommend'
import NewestList from './NewestList'
import './header.css'

class Home extends Component{
    render(){
        return(
            <div>
                <Broadcast/>
                <Recommand/>
                <NewestList/>
            </div>
        );
    }
}

export default Home;