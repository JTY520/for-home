import React, { Component } from 'react';

import { Layout, Input, Avatar,Menu } from 'antd';
import { Switch, Route, Link } from "react-router-dom";
import ModifyInformation from './ModifyInformation'
import ModifyPassword from './ModifyPassword'
import MyHouse from './MyHouse'
import MyMeassage from './MyMeassage'
import MyOrder from './MyOrder'

const {Content, Sider  } = Layout;
const img = require('../image/house1.jpg');
class Personal extends Component{
    
    render(){
        return(
            <Layout>
                <Sider
                style={{height:'100%'}}
                 trigger={null}
                 collapsible>
                 <div style={{backgroundColor:'#ffffff',textAlign:'center'}}>
                  <img src={img} width="80" height="100" alt="" style={{marginTop:10,marginBottom:10}}/>
                  <Menu theme="light" mode="inline" defaultSelectedKeys={['1']}>
                  <Menu.Item key="1">
                  <span className="nav-text"><a href="/myMeassage">个人中心</a></span>
                  </Menu.Item>
                  <Menu.Item key="2">
                  <span className="nav-text"><a href="/personal/modifyInformation">修改信息</a></span>
                  </Menu.Item>
                  <Menu.Item key="3">
                  <span className="nav-text"><a href="/modifyPassword">修改密码</a></span>
                  </Menu.Item>
                  <Menu.Item key="4">
                  <span className="nav-text"><a href="/myHouse">我的房子</a></span>
                  </Menu.Item>
                  <Menu.Item key="5">
                  <span className="nav-text"><a href="/myOrder">我的预订</a></span>
                  </Menu.Item>
                  </Menu>
                 </div>
                </Sider>
                <Content>
                    <Switch>
                      <Route  path="/modifyInformation" render={(props) => <ModifyInformation popKey={this.selectKeys} {...props}/>}/>
                      <Route  path="/modifyPassword" render={(props) => <ModifyPassword popKey={this.selectKeys} {...props}/>}/>
                      <Route  path="/myHouse" render={(props) => <MyHouse popKey={this.selectKeys} {...props} />}/>
                      <Route  path="/myMeassage" render={(props) => <MyMeassage popKey={this.selectKeys} {...props}/>}/>
                      <Route  path="/myOrder" render={(props) => <MyOrder popKey={this.selectKeys} {...props}/>}/>
                      <Route path="/" render={(props) => <MyMeassage popKey={this.selectKeys} {...props}/>}/>
                    </Switch>
                </Content>
            </Layout>
        );
    }
}

export default Personal;