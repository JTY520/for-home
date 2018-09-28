import React, { Component } from 'react';
import {  message, Modal, Input,Button } from 'antd';


class AddHouse extends Component{
    constructor(props) {
        super(props);
        this.state = {
            characterName:'',
            disable:false,
            loading:false,
        }
    }
    handleAddCha(){
        this.setState({
            disable:true,
            loading:true,
        })
        if(!this.state.characterName){
            message.error("aaa")
            return;
        }
        else{
            message.success('llll');

        }
    }
    handleClose(){
        this.setState({
            characterName:'',
            disable:false,
            loading:false,
        })
        this.props.handleCloseAddCharModal();
    }
    render(){
        return(
            <Modal
                 title="添加自己的优点"
                 visible={this.props.visible}
                 maskClosable={true}
                 onCancel={()=>this.handleClose()}
                 footer={null}>
                 <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center',width:400,height:100}}>
                  <Input value={this.state.characterName}
                      onChange={(value) => this.setState({ characterName: value.target.value })}
                      style={{ width:'90%'}}
                      placeholder="输入特点内容（2——8）"
                      size="large"
                    />
                    <Button
                   style={{ marginBottom: 0,marginTop:25, width:'80%',fontSize:17,fontWeight:500}}  
                   type="primary"
                   size="large" 
                   disabled={this.state.disable}
                   onClick={()=>this.handleAddCha()}
                   loading={this.state.loading}>添     加</Button>
                  </div>
            </Modal>
        );
    }
}
export default AddHouse;