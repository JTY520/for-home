import React, { Component } from 'react';
import {userServices} from '../lib'
class MyMeassage extends Component{
    constructor(props) {
        super(props);
        this.state={
            data:{}
        }
    }
    componentWillMount(){
        this.handleGetMyMessage()
    }
    handleGetMyMessage(){
        // userServices.getUserData(id).then((res) => {
        //     console.log(res)
        //     this.setState({loading: false,data:res.data})
        //     message.success("登录成功！");
        //      this.props.history.replace('/');
        // }).catch((err) => {
        //     this.setState({loading: false})
        //     message.error("登录失败！");
        // });
        this.setState({
            data:{account:"123123",nick:"",photo:"",phone:"123123123123",mail:""}
        })
    }
    render(){
        return(
            <div>
                <h1>个人中心</h1>
                <span>{this.state.data.account}</span>
                <span>{this.state.data.account}</span>
                <span>{this.state.data.account}</span>
                <span>{this.state.data.account}</span>
            </div>
        );
    }
}

export default MyMeassage;