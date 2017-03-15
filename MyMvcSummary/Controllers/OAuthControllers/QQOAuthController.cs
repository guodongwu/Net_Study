using Social.Tencent;
using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Security;
using Social.Options;
using Social.Tencent.Options;
using Social;

namespace Demo.Controllers.OAuthControllers
{
    public partial class QQOAuthController : BaseController
    {
        private TencentAuthenticationHandler _tencentHandler;
        private AuthenticationOptions _options;
        public QQOAuthController()
            : base()
        {
            _options = new AuthenticationOptions()
            {
                AppId = "101183920",//对应第三方appid
                AppSecret = "e5232d96ad71a9183c81a4dd461e16b5",
                AuthorizeUrl = "https://graph.qq.com",
                Host = "http://www.nongyou360.com/",
                Callback = "qqconnect",
            };
            _tencentHandler = new TencentAuthenticationHandler(_options);
        }
        public ActionResult QQLogin(string returnUrl)
        {
            AuthenticationScope scope = new AuthenticationScope()
            {
                State = Guid.NewGuid().ToString().Replace("-", ""),
                Scope = "get_user_info"
            };
            if (!string.IsNullOrEmpty(returnUrl))
            {
                Session["returnUrl"] = returnUrl;
            }
            Session["requeststate"] = scope.State;
            string url = _tencentHandler.GetAuthorizationUrl(scope);
            return Redirect(url);
        }
        public ActionResult CallBack()
        {
            var verifier = Request.Params["code"];
            string state = Session["requeststate"].ToString();
            QQAuthenticationTicket ticket = new QQAuthenticationTicket()
            {
                Code = verifier,
                Tag = "Tencent.QQ"
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