import React, { Component } from 'react';
import { Layout, Input,Divider,BackTop } from 'antd';
import { Switch, Route, Link } from "react-router-dom";

import ModifyPassword from './Personal/ModifyPassword'
import Home from './Home/index'
import HouseDetail from './HouseDetail/index'
import AddHouse from './House/AddHouse'
import SearchPage from './Search/index'
import Personal from './Personal/index'
import MyHeader from './Home/MyHeader'
import './Home/header.css'

const Search = Input.Search;
const { Header, Content, Footer } = Layout;

class App extends Component {

  constructor(props) {
    super(props);
  }
handleToAddHouse(){
  window.location.href="/addHouse"
}
handleToGetAllHouse(){
  window.location.href="/search"
}
  render() {
    return (
      <Layout>
        <Header style={{width:'100%',height:70,borderBottom: 2,borderBottomColor:'#fafafa',backgroundColor:'#ffffff'}}>
          <div className="header-flex">
            <div style={{marginLeft:20}}>
              <span style={{cursor:'pointer'}}><a href="./home">FOR-HOME</a></span>
              <span onClick={this.handleToAddHouse}
              style={{cursor:'pointer',marginLeft:10}}>卖房</span>
              <span onClick={this.handleToGetAllHouse}
              style={{cursor:'pointer',marginLeft:10}}>找房</span>
              </div>
            <div> 
              <Search placeholder="input search text"
               onSearch={value => console.log(value)}
               style={{ width: 250 }} 
               size="large"/>
            </div>
            <div style={{marginRight:20}}>
              <MyHeader/>
            </div>
          </div>
          </Header>
        <Content style={{width:'100%',paddingLeft:50,paddingRight:50,backgroundColor:'#ffffff'}}>
          <Divider style={{marginBottom:40}}/>
          <BackTop />
          <Switch>
           <Route path="/home" render={(props) => <Home popKey={this.selectKeys} {...props}/>}/>
           <Route path="/search" render={(props) => <SearchPage popKey={this.selectKeys} {...props}/>}/>
           <Route path="/personal" render={(props) => <Personal popKey={this.selectKeys} {...props} />}/>
           {/* <Route path="/modifyPassword" render={(props) => <ModifyPassword popKey={this.selectKeys} {...props} />}/> */}
           <Route path="/houseDetail" render={(props) => <HouseDetail popKey={this.selectKeys} {...props}/>}/>
           <Route path="/addHouse" render={(props) => <AddHouse popKey={this.selectKeys} {...props}/>}/>
           <Route path="/" render={(props) => <Home popKey={this.selectKeys} {...props}/>}/>
          </Switch>
        </Content>
        <Footer>
            <p>JTY-----Footer------FOR  HOME</p>
        </Footer>
      </Layout>
    );
  }
}
export default App;
