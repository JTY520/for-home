import React, { Component } from 'react';
import { Select,Input,Button } from 'antd';
import GetAllHouse from './GetAllHouse'

const Option = Select.Option;

class Search extends Component{
    constructor(props) {
        super(props);
        this.state = {
         type:0,
         characterName:'',
         keyWord:'',
         data:[],
         listData:[],
        }
      }
      componentWillMount(){
          this.handleCharacterNameGetData()
          this.handleLoadListTable();
      }
      handleLoadListTable(){
          console.log(this.state.type);
          console.log(this.state.characterName);
          console.log(this.state.keyWord);
          this.setState({
              listData:[{
                title:'Good',
                type:1,
                id:1,
                publiciTime : '12-12-12',
                summary :'HouseSummary',
                bargin : 'h.HouseBargainContent',
                masterAccount : '123456',
                masterNick : 'UserNickName',
                character: '12345_123456_',
                imageUrls:''
              }]
          })
          return;
      }
      handleCharacterNameGetData(){
          this.setState({
              data:[{value:1,text:'啦啦啦1'},{value:2,text:'啦啦啦2'},{value:3,text:'啦啦啦3'}]
          })
      }
       handleChange(value) {
        console.log(`selected ${value}`);
      }

    render(){
        return(
            <div  style={{width:'100%',height:'100%',paddingTop:10,marginBottom:10,paddingLeft:10}}>
                <div style={{width:'100%',height:50,marginBottom:10,paddingLeft:10}}>
                <Select
                 showSearch
                 style={{ width: 200,marginRight:20 }}
                 placeholder="选择要求"
                 onChange={(value) => this.setState({ characterName: value})}
                 >
                 {this.state.data.map(d => <Option value={d.text} key={d.value}>{d.text}</Option>)}
                </Select>
                <Select
                 showSearch
                 style={{ width: 200,marginRight:20 }}
                 placeholder="选择类型"
                 onChange={(value) => this.setState({ type: value})}
                 >
                 <Option value= {1}key='1'>租房</Option>
                 <Option value={2} key='2'>买房</Option>
                </Select>
                <Input  value={this.state.keyWord}
                      onChange={(value) => this.setState({ keyWord: value.target.value })}
                      placeholder="请输入。。。"
                      style={{ width:200}}/>
                <Button onClick={()=>this.handleLoadListTable()}>查询</Button>
                </div>
                <div className="list-box">
                <GetAllHouse data={this.state.listData}/>
                </div>
            </div>
        );
    }
}

export default Search;