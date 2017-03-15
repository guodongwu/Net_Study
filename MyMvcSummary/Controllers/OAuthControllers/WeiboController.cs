using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Security;
using Social.Weibo;
using Social.Wechat.Options;
using Social.Weibo.Options;
using Social.Options;
using Social;

namespace Demo.Controllers.OAuthControllers
{
    public partial class WeiboController : BaseController
    {
        private WeiboAuthenticationHandler _tencentHandler;
        private AuthenticationOptions _options;
        public WeiboController()
            : base()
        {
            _options = new AuthenticationOptions()
            {
                
                AppId = "",
                AppSecret = "",
                AuthorizeUrl = "https://api.weibo.com",
                Host="http://www.nongyou360.com/",
                Callback = "weiboconnect",
            };
            _tencentHandler = new WeiboAuthenticationHandler(_options);
        }
        public ActionResult WeiboLogin()
        {
            AuthenticationScope scope=new AuthenticationScope(){
                State=Guid.NewGuid().ToString().Replace("-", ""),
                Scope="all"
            };
            Session["requeststate"] = scope.State;
            string url=_tencentHandler.GetAuthorizationUrl(scope);
            return Redirect(url);
        }
        public ActionResult CallBack()
        {
            var verifier = Request.QueryString["code"];
            string state = Session["requeststate"].ToString();
            WeiboAuthenticationTicket ticket = new WeiboAuthenticationTicket()
            {
                Code=verifier,
                Tag = "Weibo"
            };
            ticket = _tencentHandler.PreAuthorization(ticket);
            ticket = _tencentHandler.AuthenticateCore(ticket);
            UserClaim userClaim = getUserClaimByOpenIdOrUnionId(ticket.OpenId, "", ticket.Tag);
            if (userClaim != null)
            {
                FormsAuthentication.SetAuthCookie(userClaim.User.UserName, true);
                if (Session["returnUrl"] != null && string.IsNullOrEmpty(Session["returnUrl"].ToString()))
                {
                    return Redirect(Session["returnUrl"].ToString());
                }
                return RedirectToAction("Index", "Home");
            }
            SocialUser user = _tencentHandler.GetUserInfo(ticket);
            Session["social.current"] = user;
            return RedirectToAction("social", "members");

        }
     
    }
}