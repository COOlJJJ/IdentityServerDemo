import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import userManager from '../src/Auth/SSO.js'

Vue.config.productionTip = false

Vue.prototype.$userManager = userManager

document.title = "SSO Client1"

router.beforeEach(async (to, from, next) => {
  if (to.name === 'callback') {
    next()
  } else if (to.name === 'signout-callback-oidc') {
    console.log('log out....')
  } else {
    const user = await userManager.getUser();
    console.log(user);
    if (user) {
      next()
    }
    else {
      userManager.signinRedirect().catch(error => {
        console.error(error)
      })
    }

  }
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
