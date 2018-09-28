import React, { Component } from 'react';
import { Carousel } from 'antd';
import './house.css'

const img1 = require('../image/house1.jpg')
const img2 = require('../image/house2.jpg')
const img3 = require('../image/house3.jpg')

class Images extends Component{
    constructor(props) {
        super(props);
    }
    render(){
        return(
            <Carousel className="images-box" autoplay>
             <div>
              <img width="600" height="400" src={img1} alt=""/> </div>
             <div>
              <img  width="600" height="400" src={img2} alt=""/></div>
             <div>
              <img  width="600" height="400" src={img3} alt=""/></div>
            </Carousel>
        );
    }
}
export default Images;