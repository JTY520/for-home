import React, { Component } from 'react';
import { List, Avatar, Divider,Tag} from 'antd';
import './header.css'

const img = require('../image/house3.jpg')
class NewestList extends Component{
    state = {
        data: [],
      }
      componentWillMount(){
          this.handleLoadData()
      }
      handleLoadData=()=>{
          this.setState({data : [
              {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
              {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
              {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
              {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
            ]});
      }
    render(){
        return(
            <div className="newest-box">
               <Divider style={{fontSize:16,fontWeight:300}} orientation="left">最新发布</Divider>
               <List
                 itemLayout="vertical"
                 dataSource={this.state.data}
                 footer={<div style={{marginBottom:20}}><span style={{float:'right'}}><a href="/search"> >>>更多 </a></span></div>}
                 className="newest-list"
                 renderItem={item => (
                    <List.Item
                    key={item.title}
                    extra={<img width={150} height={80} alt="logo" src={img} />}
                    >
                     <List.Item.Meta
                      title={item.title}
                      description={item.description}
                      />
                     <Tag color="gold">美丽</Tag>
                         <Tag  color="gold">大方</Tag>
                         <Tag  color="gold">好看</Tag>
                         <Tag  color="gold">简洁</Tag>
                     </List.Item>
                    )}
                />
            </div>
        );
    }
}

export default NewestList;

