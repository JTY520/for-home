import React, { Component } from 'react';
import { List, Avatar,Divider, Button,Modal } from 'antd';
import AddComment from './AddComment';

const img = require('../image/house2.jpg')
class Comment extends Component{
    constructor(props) {
        super(props);
        this.state = {
          data:[],
          commentVisible:false
        };
    }
    componentWillMount(){
        this.handleGetComment()
    }
    handleGetComment(){
        this.setState({
            data:[{userAccount:'123123',content:'hhhhhhhhhh'}]
        })
    }
    handleCloseModal=()=>{
        this.setState({
            commentVisible:false
        })
    }
    handleShowModel=()=>{
        this.setState({
            commentVisible:true
        })
    }


handleLoadComment(){
    this.setState({
        data:[
            {
                userAccount:"123456",
                content:"swdfegrthyj"
            }, {
                userAccount:"123456",
                content:"swdfegrthyj"
            }, {
                userAccount:"123456",
                content:"swdfegrthyj"
            }, {
                userAccount:"123456",
                content:"swdfegrthyj"
            }
        ]
    })
}
    render(){
        return(
            <div style={{width:'80%',height:'100%',marginBottom:50,border:'1px',borderColor:'#f1f1f1',float:'left'}}>
            <Button onClick={this.handleShowModel} style={{float:'right',marginTop:5,marginRight:20}}>写评论</Button>
            <AddComment visible={this.state.commentVisible} handleCloseModal={this.handleCloseModal}/>
            <Divider/>
            <List
             itemLayout="horizontal"
             dataSource={this.state.data}
             renderItem={item => (
                <List.Item>
                 <List.Item.Meta
                   avatar={<Avatar src={img} />}
                   title={<span>{item.userAccount}</span>}
                   description={item.content}
                   />
               </List.Item>
             )}
             />
            </div>
        );
    }


}
export default Comment;