import React, { Component } from 'react';
import { List, Avatar, Divider,Icon,message} from 'antd';
import './header.css'
import {houseService} from '../lib'

const img = require('../image/house3.jpg')
const IconText = ({ type, text }) => (
    <span>
      <Icon type={type} onClick={this.handleClickIcon} style={{ marginRight: 8 }} />
      {text}
    </span>
  );
class Recommend extends Component{
    state = {
        data: [],
      }
      componentWillMount(){
          this.handleLoadData()
      }
      handleClickIcon(type){
          console.log(type);
      }
      handleLoadData=()=>{
        //   this.setState({data : [
        //       {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
        //       {title: '123456',: img,description: 'beautiful',content: 'We supp'},
        //       {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
        //       {title: '123456',avatar: img,description: 'beautiful',content: 'We supp'},
        //     ]});
        houseService.getRecommentList().then((res)=>{
            if(res!=null){
                let list = res.data.data;
                for(let i =0;i < list.length();i++){
                    list[i].Avatar = img;
                }
                 this.setState({
                data:list
             })
             return;
            }
        })
        message.error("error");
      }
    render(){
        return(
            <div className="recommand-box">
               <Divider style={{fontSize:16,fontWeight:300}} orientation="left">今日推荐</Divider>
               <List
                 itemLayout="vertical"
                 dataSource={this.state.data}
                 footer={null}
                 className="recommand-list"
                 renderItem={item => (
                    <List.Item
                    key={item.title}
                    actions={[<IconText type="like-o" text="156" />, <IconText type="message" text="2" />]}
                    extra={<a href="/houseDetail"><img width={150} height={80} alt="logo" src={img} /></a>}
                    >
                     <List.Item.Meta
                      title={item.title}
                      description={item.description}

                      />
                     {item.content}
                     </List.Item>
                    )}
                />
            </div>
        );
    }
}

export default Recommend;

