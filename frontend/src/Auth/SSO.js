import Oidc from 'oidc-client'

const host = location.origin

//授权认证服务器
const authsServer = 'http://localhost:5002'

const userManager = new Oidc.UserManager({
    authority: authsServer,  // server 地址
    client_id: 'vue client',  // client id
    client_secret: '511536EF-F270-4058-80CA-1C89C192F69A',//密钥
    post_logout_redirect_uri: `${host}/signout-callback-oidc`, // 退出登录
    redirect_uri: `${host}/callback`,
    silent_redirect_uri: `${host}/callback`,
    accessTokenExpiringNotificationTime: 4,  // 超时
    silentRequestTimeout: 2000,  // 
    //简化模式—— Implicit
    //response_type: 'token id_token', 
    //授权码模式
    response_type: 'code',
    scope: 'openid profile code_scope1',
    filterProtocolClaims: true,
    //踩了个坑 对过期令牌校验 默认为true  改为false才不校验 否则一直登陆 大坑~~！！！！！
    monitorSession: false
})

userManager.events.addUserSignedOut(() => {
    userManager.removeUser().then(() => {
        userManager.signinRedirect().catch(() => {
            console.error('error wihile logout')
        })
    })

})

export default userManager;