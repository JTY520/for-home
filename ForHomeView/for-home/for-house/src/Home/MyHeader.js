import React, { Component } from 'react';
import {Link} from "react-router-dom";
import { connect } from 'react-redux';
import {userServices} from '../lib'
import {message} from 'antd'

import Login from '../Account/Login'
import Register from '../Account/register'

class MyHeader extends Component{
    constructor(props) {
        super(props);
        this.state = {
          LoginVisible:false,
          RegisterVisible:false,
          isLogin:false,
          user:{}
        }
      }
        componentWillMount(){
          this.handleJugeLogin()
        } 
      handleJugeLogin=()=>{
        let user = this.props.user;
        if (user == null) {
          this.setState({isLogin:false});
          return;
        }
        this.setState({
          isLogin:true,
          user:user
        });
        return;
      }
      handleShowLoginModal=()=>{
        this.setState({
          LoginVisible:true
        });
      }
      handleShowRegisterModal=()=>{
        this.setState({
          RegisterVisible:true
        });
      }
      handleCancelModal=()=>{
        this.setState({
          LoginVisible:false,
          RegisterVisible:false
        });
      }
      handleLogout=()=>{
        userServices.logout().then(()=>{
          message.success("注销成功！");
        })
      }
    render(){
        if(this.state.isLogin === true){
            return(
              <div>
                 <span onClick={this.handleShowLoginModal} style={{cursor:'pointer'}}>登录</span>
                 <em>|</em>
                 <span  style={{cursor:'pointer'}} onClick={this.handleShowRegisterModal}>注册</span>
                 <Login visible={this.state.LoginVisible} handleCancelModal={this.handleCancelModal}/>
                 <Register visible={this.state.RegisterVisible} handleCancelModal={this.handleCancelModal} />
              </div>
          );
        }
        else{
            return(
                <div>
                 <span  style={{cursor:'pointer'}}><Link to="./personal">个人中心</Link></span>
                 <em>|</em>
                 <span  style={{cursor:'pointer'}} onClick={this.handleLogout}>注销</span>
                </div>
            );
        }
    }
}

const mapStateToProps = (state) => {
  return {
      user: state.Session.User,
  }
}
MyHeader = connect(mapStateToProps)(MyHeader)
export default MyHeader;             