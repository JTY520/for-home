import React, { Component } from 'react';
import{Button,Input,message,Modal} from 'antd'

const { TextArea } = Input;
class AddComment extends Component{
    constructor(props) {
        super(props);
        this.state = {
          content:'',
          disable:false,
          loading:false,
        };
    }

    handleAddComment(){
        this.setState({
            disable:true,
            loading:true,
        })
        if(!this.state.content){
            message.error("error");
            return;
        }
        else{
            message.success("asdfghj");
        }
    }

    handleClose=()=>{
        this.setState({
            disable:false,
            loading:false,
            content:'',
        })
        this.props.handleCloseModal();
    }

    render(){
        return(
            <Modal
                 title="添加评论"
                 visible={this.props.visible}
                 maskClosable={true}
                 onCancel={this.handleClose}
                 footer={null}>
                <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center',width:400,height:200}}>
                  <TextArea value={this.state.content}
                      onChange={(value) => this.setState({ content: value.target.value })}
                      style={{ width:'90%'}}
                      rows="3"
                    />
                    <Button
                   style={{ marginBottom: 0,marginTop:25, width:'90%',fontSize:17,fontWeight:500}}  
                   type="primary"
                   size="large" 
                   disabled={this.state.disable}
                   onClick={()=>this.handleAddComment()}
                   loading={this.state.loading}>提交</Button>
                  </div>
            </Modal>
        );
    }
}
export default AddComment;