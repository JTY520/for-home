import React, { Component } from 'react';
import HouseImages from './images';
import Comment from './Comment';
import { Divider,Tag, Button } from 'antd';
import AddOrder from './orderMeaaage'

class HouseDetail extends Component{
    constructor(props) {
        super(props);
        this.state = {
            data:{},
            orderVisible:false
        }
    }
    componentWillMount(){
        this.handLOadHouse();
    }
    handleCloseModal=()=>{
        this.setState({
            orderVisible:false
        })
    }
    handleShowModel=()=>{
        this.setState({
            orderVisible:true
        })
    }

    handLOadHouse(){
        this.state.data = {
            title:'Good',
            type:1,
            id:1,
            publiciTime : '12-12-12',
            place:'在这里',
			summary :'HouseSummary',
			bargin : 'h.HouseBargainContent',
			masterAccount : '123456',
			masterNick : 'UserNickName',
            character: '12345_123456_',
            imageUrls:''
        }
    }
    render(){
        return(
            <div style={{width:'100%',height:'100%',paddingLeft:20,paddingTop:10}}>
             <h2>{this.state.data.title}</h2>
             <div style={{width:'100%',height:20}}>
               <Tag color="gold">美丽</Tag>
               <Tag color="gold">大方</Tag>
               <Tag color="gold">安静</Tag>
               <Tag color="gold">幽深</Tag>
               <em>|</em>
               <strong>招租中</strong>
               <span>地点：{this.state.data.place}</span>
             </div>
             <Divider/>
             <HouseImages/>
             <div style={{width:200,height:300,float:'left',marginLeft:50,textAlign:'center'}}>
             <div style={{width:'100%',height:150,}}>
                 <p> 123412324 </p>
             </div>
               
               <Button type="primary" size="large" onClick={this.handleShowModel}>预约看房</Button>
               <AddOrder visible={this.state.orderVisible} handleCloseModal={this.handleCloseModal}/>
             </div >
             <Comment/>
            </div>
        );
    }
}
export default HouseDetail;