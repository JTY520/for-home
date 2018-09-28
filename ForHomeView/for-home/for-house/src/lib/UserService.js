import axios from 'axios';
import Store from "./store";
import config from './config';

export default class Service {
//     static get token() {
//         console.log(global.Store.getState().Session.Token);
//         return global.Store.getState().Session.Token;
//     }
    static get commonService() {
        let service = axios.create({
            baseURL: `${config.service.url}/api`,
            //headers: { Token: Service.token, 'App-Version': '0.1.0' }
        });
        service.defaults.timeout = 12000;
        return service;
    }
    static get sessionService() {
        let service = axios.create({
            baseURL: `${config.service.url}/api`,
        });
        service.defaults.timeout = 12000;
        return service;
    }
    static sign_in(data) {
        return new Promise(function (resolve, reject) {
            Service.sessionService.post(`/User/Login?userName=${data.userName}&password=${data.password}`).then((ret) => {
                Store.dispatch({
                    type: 'SESSION:UP',
                    user: {
                        id: ret.data.userId,
                        nickName: ret.data.userNickName,
                        account:ret.data.userAccount,
                        phone:ret.data.userPhone
                    }
                });
                resolve(ret)
            }).catch(reject)
        });
    }

    static getUserData(userId) {
        return Service.sessionService.get(`/User/MyMessage?userId=${userId}`);
    }

    static modify_password(params = {}) {
        return Service.sessionService.put('/User/MOdifyPassword', 
        params = {
            
            old_password: params.old_password,
            new_password: params.new_password,
        }
    );
    }
    static modify_information(params = {}) {
        return Service.sessionService.post('/mobile/me/home/information',
            params = {
                phone: params.phone,
                qq: params.qq
            }
        );
    }
    static modify_haedImg(params = {}) {
        return Service.sessionService.put('/mobile/me/home/photo',
        params={
            photo:params.photo
        }
    );
    }
    static logout(){
        return new Promise(function (resolve, reject) {
            Store.dispatch({
                type: 'SESSION:DOWN'
            });
        });
    }
}