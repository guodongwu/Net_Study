	//----------Sys_User开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_User 
        /// </summary>
        [Serializable()]
        public class Sys_User
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  UserId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  UserGuid {get;set;}   
                         
			/// <summary>
			/// String:用户名
			/// </summary>                       
			public string  UserName {get;set;}   
                         
			/// <summary>
			/// String:真实姓名
			/// </summary>                       
			public string  RealName {get;set;}   
                         
			/// <summary>
			/// String:密码
			/// </summary>                       
			public string  Password {get;set;}   
                         
			/// <summary>
			/// String:身份证号
			/// </summary>                       
			public string  IdCard {get;set;}   
                         
			/// <summary>
			/// String:头像
			/// </summary>                       
			public string  Portrait {get;set;}   
                         
			/// <summary>
			/// Byte:性别
			/// </summary>                       
			public byte?  Gender {get;set;}   
                         
			/// <summary>
			/// DateTime:生日
			/// </summary>                       
			public DateTime?  Birthday {get;set;}   
                         
			/// <summary>
			/// Int32:年龄
			/// </summary>                       
			public int?  Age {get;set;}   
                         
			/// <summary>
			/// String:昵称
			/// </summary>                       
			public string  Nick {get;set;}   
                         
			/// <summary>
			/// String:电话
			/// </summary>                       
			public string  Phone {get;set;}   
                         
			/// <summary>
			/// String:e-mail
			/// </summary>                       
			public string  Email {get;set;}   
                         
			/// <summary>
			/// Boolean:状态
			/// </summary>                       
			public bool  Status {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  AddTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  AddIp {get;set;}   
                         
			/// <summary>
			/// String:qq
			/// </summary>                       
			public string  QQ {get;set;}   
                         
			/// <summary>
			/// String:登录key
			/// </summary>                       
			public string  LoginKey {get;set;}   
                         
			/// <summary>
			/// String:登录key类型  qq weixin sina
			/// </summary>                       
			public string  LoginKeyType {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Education {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Address {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Nation {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  ZipCode {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Profile {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  LastLoginTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  LastLoginIp {get;set;}   
               
        }    
     }

	//----------Sys_User结束----------

	