import React, { Component } from 'react';
import {  message, Modal, Input,Button } from 'antd';

class Register extends Component{
    constructor(props) {
        super(props);
        this.state = {
          lading:false,
          account:'',
          password:'',
          confirmPassword:'',
          phone:'',
          display1:'block',
          display2:'none',
          disable:false
        } 
    }
    handleRegister=()=>{
         if(!this.state.password){
            message.error("password");
        }
        else if(!this.state.confirmPassword){
            message.error("confirmPassword");
        }
        else if(this.state.password !== this.state.confirmPassword){
            message.error("password != confirmPassword");
        }
        else{
            //window.location.href="./home";
            message.success("success");
        }
    }

    handleClose=()=>{
        this.setState({
            account:'',
            phone:'',
            password:'',
            confirmPassword:''
        });
        this.props.handleCancelModal();
    }
    handleNext=()=>{
        if(!this.state.account){
            message.error("account");
            return;
        }
        else if(!this.state.phone){
            message.error("phone");
            return;
        }
        else{
            this.setState({
                display1:'none',
                display2:'block'
            })
        }
    }
    render(){
        return(
            <Modal
            title="Register"
            visible={this.props.visible}
            maskClosable={true}
            style={{height:400,width:400}}
            onCancel={this.handleClose}
            footer={null}>
              <div style={{display:this.state.display1,height:250}}>
                  <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center' }}>
                  <Input value={this.state.account}
                     style={{ width:'80%'}}
                     placeholder="请输入用户名"
                     size="large" 
                      onChange={(value) => this.setState({ account: value.target.value })}
                    />
                  </div>
                  <div style={{ marginBottom: 0, marginTop: 25,textAlign:'center' }}>
                  <Input value={this.state.phone}
                     style={{ width:'80%'}}
                     placeholder="请输入手机号码"
                     size="large"
                     onChange={(value) => this.setState({ phone: value.target.value })}
                    />
                  </div>
                  <div   style={{width:'100%',marginTop: 20 ,textAlign:'center'}}>
                  <Button
                   style={{ marginBottom: 0, width:'80%',fontSize:17,fontWeight:500}}  
                    size="large" 
                   type="primary"
                    onClick={this.handleNext}>下一步</Button>
                  </div>
              </div>
              <div style={{display:this.state.display2,height:250}}>
              <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center' }}>
                  <Input value={this.state.password}
                     style={{ width:'80%'}}
                     placeholder="请输入密码"
                     size="large" 
                      onChange={(value) => this.setState({ password: value.target.value })}
                    />
                  </div>
                  <div style={{ marginBottom: 0, marginTop: 25,textAlign:'center' }}>
                  <Input value={this.state.confirmPassword}
                     style={{ width:'80%'}}
                     placeholder="确认密码"
                     size="large"
                     onChange={(value) => this.setState({ confirmPassword: value.target.value })}
                    />
                  </div>
                  <div  style={{width:'100%',marginTop: 20 ,textAlign:'center'}}>
                  <Button 
                  style={{ marginBottom: 0, width:'80%',fontSize:17,fontWeight:500}}  
                  type="primary"
                  size="large" 
                  disabled={this.state.disable}
                  loading={this.state.loading}
                  onClick={this.handleRegister}>注  册</Button>
                  </div>
              </div>
            </Modal>
        );
    }
}

export default Register;