import React, { Component } from 'react';
import {  message, Modal, Input,Button,Tabs } from 'antd';
import {userServices} from '../lib'

const TabPane = Tabs.TabPane;
class Login extends Component{
    constructor(props) {
        super(props);
        this.state = {
          laoding:false,
          password:'',
          account:'',
          phone:'',
          phonePass:'',
          disable:false
        } 
    }

    handleAccountLogin=()=>{
        this.setState({disable:true})
        if(!this.state.account){
            this.setState({disable:false})
            message.error("account");
            return;
        }
        else if(!this.state.password){
            this.setState({disable:false})
            message.error("password");
            return;
        }
        else{
            this.setState({loading: true});
            userServices.sign_in({userName:"account_"+this.state.account,password:this.state.password}).then((res) => {
                console.log(res)
                this.setState({loading: false})
                message.success("登录成功！");
                 this.props.history.replace('/');
            }).catch((err) => {
                this.setState({loading: false})
                message.error("登录失败！");
            });
        }
    }
    handlePhoneLogin=()=>{
        this.setState({disable:true})
        if(!this.state.phone){
            message.error("account");
            this.setState({disable:false})
            return;
        }
        else if(!this.state.phonePass){
            this.setState({disable:false})
            message.error("password");
            return;
        }
        else{
            this.setState({loading: true});
            // userServices.sign_in({userName:"account_"+account,password:password}).then((res) => {
            //     this.setState({loading: false})
            //     this.props.history.replace('/');
            //     message.success("登录成功！")
            // }).catch((err) => {
            //     this.setState({loading: false})
            //     message.error("登录失败！");
            // });
            // window.location.href="./home";
        }
    }
    handleClose=()=>{
        this.setState({
            account:'',
            password:'',
            phone:'',
            phonePass:'',
            disable:false
        });
        this.props.handleCancelModal();
    }

    render(){
        return(
            <div>
                <Modal
                 title="Login"
                 visible={this.props.visible}
                 maskClosable={true}
                 onCancel={this.handleClose}
                 footer={null}>
                 <Tabs  defaultActiveKey="1" style={{height:300}}>
                 <TabPane  tab="账户密码登录" key="1">
                  <div>
                  <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center'}}>
                  <Input value={this.state.account}
                      onChange={(value) => this.setState({ account: value.target.value })}
                      style={{ width:'80%'}}
                      placeholder="请输入用户名"
                      size="large"
                    />
                  </div>
                  <div style={{ marginBottom: 0,marginTop: 25,textAlign:'center'}}>
                  <Input type="password" value={this.state.password}
                      onChange={(value) => this.setState({ password: value.target.value })}
                      placeholder="请输入密码"
                      style={{ width:'80%'}}
                      size="large"
                    />
                  </div>
                  <div style={{width:'100%',marginTop: 20 ,textAlign:'center'}}>
                  <Button
                   style={{ marginBottom: 0, width:'80%',fontSize:17,fontWeight:500}}  
                   type="primary"
                   size="large" 
                   disabled={this.state.disable}
                   onClick={this.handleAccountLogin}
                   loading={this.state.loading}>登     录</Button>
                  </div>
                  </div>
                 </TabPane>
                 <TabPane  tab="手机号登陆" key="2">
                 <div>
                  <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center'}}>
                  <Input value={this.state.phone}
                      onChange={(value) => this.setState({ account:value.target.value })}
                      style={{ width:'80%'}}
                      placeholder="请输入手机号"
                      size="large"
                    />
                  </div>
                  <div style={{ marginBottom: 0,marginTop: 25,textAlign:'center'}}>
                  <Input type="password" value={this.state.phonePass}
                      onChange={(value) => this.setState({ password: value.target.value })}
                      placeholder="请输入用密码"
                      style={{ width:'80%'}}
                      size="large"
                    />
                  </div>
                  <div style={{width:'100%',marginTop: 20 ,textAlign:'center'}}>
                  <Button
                   size="large"
                   style={{ marginBottom: 0, width:'80%',fontSize:17,fontWeight:500}}  
                   type="primary" 
                   disabled={this.state.disable}
                   loading={this.state.lading} onClick={this.handlePhoneLogin}>登     录</Button>
                  </div>
                  </div>
                 </TabPane>
                 </Tabs>
                </Modal>
            </div>
        );
    }
}

export default Login;