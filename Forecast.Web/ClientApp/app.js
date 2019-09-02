import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'

// import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr"
import * as signalR from "@aspnet/signalr"

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

import jquery from 'jquery'
window.$ = jquery
window.jQuery = jquery

 // var signalR = require('./signalr.min_.js');
 // var signalR = require('./signalr.min.js');

// Vue.prototype.$signalR = HubConnectionBuilder;
Vue.prototype.$signalR = signalR;
Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
