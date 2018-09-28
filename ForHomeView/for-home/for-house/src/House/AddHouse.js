import React, { Component } from 'react';
import {TreeSelect ,Upload, Modal, Divider,Form, Input, Tooltip, Icon, Cascader, Select, Row, Col, Checkbox, Button, AutoComplete } from 'antd';
import AddCharacteristic from './AddCharacteristic'

const FormItem = Form.Item;
const Option = Select.Option;
const { TextArea } = Input;
const TreeNode = TreeSelect.TreeNode;


function getBase64(img, callback) {
  const reader = new FileReader();
  reader.addEventListener('load', () => callback(reader.result));
  reader.readAsDataURL(img);
}

class AddHouseForm extends Component{
    constructor(props) {
        super(props);
        this.state = {
            data:{},
            characteristicList:[],
            AddCharVisible:false,
        }
    }

    
    handleChange = (e) => {
      var reader = new FileReader();
      reader.onload = (function (file) {
          return function (e) {
             //console.log(this.result); //这个就是base64的数据了
            //  UserServices.modify_haedImg({photo:this.result}).then((ret) => {
            //   message.success("成功");
            //   window.location.href="./personal";              }).catch((err) => {
            //   if (err.response && err.response.status !== 404)
            //     message.error("连接超时");
            // });
          };
      })(e.target.files[0]);
      reader.readAsDataURL(e.target.files[0]);
  }

    componentWillMount(){
      this.handleGetAllCharacteristic()
    }
    handleGetAllCharacteristic=()=>{
        this.setState({//value, label
            characteristicList:[{value:1,label:"美丽"},
            {value:2,label:"大方"},{value:3,label:"简洁"},{value:4,label:"华丽"}]
        })
    }
    handleCloseAddCharModal=()=>{
        this.setState({
            AddCharVisible:false
        })
    }
    handleShowAddCharModal=()=>{
        this.setState({
            AddCharVisible:true,
        })
    }
    
    handleSubmit = (e) => {
        e.preventDefault();
        this.props.form.validateFields((err, fieldsValue) => {
          if (err) {
            return;
          }
          console.log(this.props.form);
        });
    }

    render(){
        const { getFieldDecorator } = this.props.form;
        return(
            <div style={{width:'100%',height:'100%',paddingLeft:20}}>
              <h2>我要交易</h2>
              <Divider/>
              <Form onSubmit={this.handleSubmit}>
              <FormItem
                label="标题"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('title', {
                    rules: [{ required: true, message: '标题不能为空' }],
                  })(
                    <Input />
                  )}
                </FormItem>
                <FormItem
                label="类型"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('type', {
                    rules: [{ required: true, message: '类型不能为空' }],
                  })(
                    <Select
                    showSearch
                    style={{ width: 200,marginRight:20 }}
                    placeholder="选择类型"
                    >
                    <Option value= {1}key='1'>出租</Option>
                    <Option value={2} key='2'>卖房</Option>
                   </Select>
                  )}
                </FormItem>
                <FormItem
                label="简介"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('summary', {
                    rules: [{ required: false}],
                  })(
                    <TextArea rows="3"/>
                  )}
                </FormItem>
                <FormItem
                label="地址"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('place', {
                    rules: [{ required: true,message:"地点不能为空"}],
                  })(
                    <Input/>
                  )}
                </FormItem>
                <FormItem
                label="要求"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('bargainContent', {
                    rules: [{ required: false}],
                  })(
                    <TextArea rows="3"/>
                  )}
                </FormItem>
                <FormItem
                label="价格"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('money', {
                    rules: [{ required: true,message:"价格不能为空"}],
                  })(
                    <Input />
                  )}
                </FormItem>
                <FormItem
                label="优点"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('characteristic', {
                    rules: [{ required: false,message:"价格不能为空"}],
                  })(
                     <div>
                         <TreeSelect
                    treeData={this.state.characteristicList}
                    showSearch
                    style={{ width: 300 }}
                    dropdownStyle={{ maxHeight: 400, overflow: 'auto' }}
                    allowClear
                    multiple
                    treeDefaultExpandAll
                    />
                    <Button onClick={this.handleShowAddCharModal}>自行添加特点</Button>
                    <AddCharacteristic visible={this.state.AddCharVisible}
                     handleCloseAddCharModal={this.handleCloseAddCharModal}/>
                     </div>
                    
                  )}
                </FormItem>
                <FormItem
                  label="上传图片"
                labelCol={{ span: 5 }}
                wrapperCol={{ span: 12 }}>
                {getFieldDecorator('stopTime', {
                    rules: [{ required: false }],
                  })(
                    <div style={{ position: "relative",width:40,height:30 }}>
                    <strong>添加图片</strong>
                    <input type="file" accept=".jpg,.jpeg,.png" onChange={this.handleChange} style={{ opacity: 0, position: "absolute", left: 0, top: 0 }} className="Header-img" />
                </div>
                  )}
                </FormItem>
                <FormItem 
                wrapperCol={{ span: 12 }}>
                <Button type="primary" style={{width:200,marginLeft:100}} htmlType="submit">Register</Button>
                </FormItem>
              </Form>
            </div>
        );
    }
}
const AddHouse = Form.create()(AddHouseForm);
export default AddHouse;