import React, { Component } from 'react';
import{Button,Input,message,Modal} from 'antd'

const { TextArea } = Input;
class AddOrder extends Component{
    constructor(props) {
        super(props);
        this.state = {
          time:'',
          place:'',
          contackWay:'',
          disable:false,
          loading:false,
        };
    }


    handleClose=()=>{
        this.setState({
            time:'',
          place:'',
          contackWay:'',
            disable:false,
            loading:false,
        })
        this.props.handleCloseModal();
    }

    render(){
        return(
            <Modal
                 title="预约内容"
                 visible={this.props.visible}
                 maskClosable={true}
                 onCancel={this.handleClose}
                 footer={null}>
                <div>
                  <div style={{ marginBottom: 0, marginTop: 10,textAlign:'center'}}>
                  <Input value={this.state.time}
                      onChange={(value) => this.setState({ time: value.target.value })}
                      style={{ width:'80%'}}
                      placeholder="请输入预约时间"
                      size="large"
                    />
                  </div>
                  <div style={{ marginBottom: 0,marginTop: 25,textAlign:'center'}}>
                  <Input  value={this.state.place}
                      onChange={(value) => this.setState({ place: value.target.value })}
                      placeholder="请输入预约地点"
                      style={{ width:'80%'}}
                      size="large"
                    />
                  </div>
                  <div style={{ marginBottom: 0,marginTop: 25,textAlign:'center'}}>
                  <TextArea  value={this.state.contackWay}
                      onChange={(value) => this.setState({ contackWay: value.target.value })}
                      placeholder="请输入联系方式"
                      style={{ width:'80%'}}
                      rows="3"
                    />
                  </div>
                  <div style={{width:'100%',marginTop: 20 ,textAlign:'center'}}>
                  <Button
                   style={{ marginBottom: 0, width:'80%',fontSize:17,fontWeight:500}}  
                   type="primary"
                   size="large" 
                   disabled={this.state.disable}
                   onClick={this.handleAccountLogin}
                   loading={this.state.loading}>确定预约</Button>
                  </div>
                  </div>
            </Modal>
        );
    }
}
export default AddOrder;