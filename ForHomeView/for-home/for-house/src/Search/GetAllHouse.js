import React, { Component } from 'react';
import {List,Tag,Divider, Button} from 'antd'
const img = require('../image/house3.jpg')
class GetAllHouse extends Component{
    constructor(props) {
        super(props);
      }
      
    render(){
        return(
            <List
            itemLayout="vertical"
            dataSource={this.props.data}
            // footer={<div style={{marginBottom:20}}><span style={{float:'right'}}><a href="/search"> >>>更多 </a></span></div>}
            style={{width:'80%',height:'100%'}}
            renderItem={item => (
               <List.Item
               key={item.title}
               extra={<img width={200} height={180} alt="logo" src={img} />}
               >
                <List.Item.Meta
                 title={item.title}
                 description={item.summary}
                 />
                 <div style={{width:730,height:'100%'}}>
                  <Tag color="gold">美丽</Tag>
                  <Tag  color="gold">大方</Tag>
                  <Tag  color="gold">好看</Tag>
                  <Tag  color="gold">简洁</Tag>
                  <Divider/>
                  <Tag  color="green">￥123/月/</Tag>
                  <Tag color="red">卖房</Tag>
                 </div>
                </List.Item>
               )}
           />
        );
    }
}

export default GetAllHouse;