
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Social;
using Social.Options;
using Social.Wechat;
using Social.Wechat.Options;

namespace Demo.Controllers.OAuthControllers
{
    public class WechatController : BaseController
    {
        private WechatAuthenticationHandler _tencentHandler;
        private AuthenticationOptions _options;
        public WechatController()
            : base()
        {
            _options = new AuthenticationOptions()
            {
                AppId = "",
                AppSecret = "",
                AuthorizeUrl = "https://graph.qq.com",
                Host="http://www.nongyou360.com/",
                Callback ="wechatconnect",
            };
            _tencentHandler = new WechatAuthenticationHandler(_options);
        }
        public ActionResult QQLogin()
        {
            AuthenticationScope scope=new AuthenticationScope(){
                State=Guid.NewGuid().ToString().Replace("-", ""),
                Scope = "snsapi_login"
            };
            Session["requeststate"] = scope.State;
            string url=_tencentHandler.GetAuthorizationUrl(scope);
            return Redirect(url);
        }
        public ActionResult CallBack()
        {
            try
            {
                var verifier = Request.Params["code"];
                string state = Session["requeststate"].ToString();
                if (!state.Contains(Request.Params["state"].ToString()))
                {
                    return Content("错误,请稍后重试");
                }
                WechatAuthenticationTicket ticket = new WechatAuthenticationTicket()
                {
                    Code = verifier
                };
                ticket = _tencentHandler.PreAuthorization(ticket);
                ticket = _tencentHandler.AuthenticateCore(ticket);
                SocialUser user = _tencentHandler.GetUserInfo(ticket);
                if (null != user)
                {
                    return Content("");
                }
            }
            catch (SocialExeception ex)
            {
                return Content("");
            }
            return Content("");
        }
    }
}