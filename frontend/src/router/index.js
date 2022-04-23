import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import LoginCallbackView from '@/views/LoginCallbackView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/callback',
    name: 'callback',
    component: LoginCallbackView
  },
]

const router = new VueRouter({
  routes,
  mode:'history'
})

export default router
