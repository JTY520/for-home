import axios from 'axios';
import Store from "./store";
import config from './config';

export default class Service {
//     static get token() {
//         console.log(global.Store.getState().Session.Token);
//         return global.Store.getState().Session.Token;
//     }
    // static get commonService() {
    //     let service = axios.create({
    //         baseURL: `${config.service.url}/api`,
    //         //headers: { Token: Service.token, 'App-Version': '0.1.0' }
    //     });
    //     service.defaults.timeout = 12000;
    //     return service;
    // }
    static get sessionService() {
        let service = axios.create({
            baseURL: `${config.service.url}/api`,
        });
        service.defaults.timeout = 12000;
        return service;
    }
    static sign_in(data) {
        return new Promise(function (resolve, reject) {
            Service.sessionService.post(`/User/Login`, data).then((ret) => {
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

    static GetHouseDetial(data = {}) {
        return Service.commonService.get('/mobile/me/home', { data });
    }
    static GetRecommentHouse(){

    }
   static AddHouse(){

   }
   static AddCharacter(){

   }
   static GetAllHouse(){

   }
   
    
}