import React, { Component } from 'react';
import { Carousel } from 'antd';
import './header.css'

const img1 = require('../image/house1.jpg')
const img2 = require('../image/house2.jpg')
const img3 = require('../image/house3.jpg')

class Broadcast extends Component{
    render(){
        return(
            <Carousel className="broadcast-box" autoplay>
             <div>
              <img width="800" height="500" src={img1} alt=""/> </div>
             <div>
              <img  width="800" height="500" src={img2} alt=""/></div>
             <div>
              <img  width="800" height="500" src={img3} alt=""/></div>
            </Carousel>
            );
    }
}

export default Broadcast;
