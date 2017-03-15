using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


public class UserClaim
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 用户Id
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// 用户认证类型
    /// </summary>
    public string Tag { get; set; }
    /// <summary>
    /// OpenId
    /// </summary>
    public string OpenId { get; set; }
    /// <summary>
    /// UnionId
    /// </summary>
    public string UnionId { get; set; }
    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; }
    /// <summary>
    /// RefreshToken
    /// </summary>
    public string RefreshKey { get; set; }

    public virtual MembershipUser User { get; set; }

}
