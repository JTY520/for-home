import axios from 'axios';
import Store from "./store";
import config from './config';

export default class Service {
//     static get token() {
//         console.log(global.Store.getState().Session.Token);
//         return global.Store.getState().Session.Token;
//     }
    static get sessionService() {
        let service = axios.create({
            baseURL: `${config.service.url}/api`,
        });
        service.defaults.timeout = 12000;
        return service;
    }
   static getRecommentList(){
    return Service.sessionService.get(`/House/RecommendList`);
   }
}