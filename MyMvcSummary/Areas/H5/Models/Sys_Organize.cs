	//----------Sys_Organize开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Organize 
        /// </summary>
        [Serializable()]
        public class Sys_Organize
        {    
		                 
			/// <summary>
			/// String:组织主键
			/// </summary>                       
			public string  OrganizeId {get;set;}   
                         
			/// <summary>
			/// String:父级
			/// </summary>                       
			public string  ParentId {get;set;}   
                         
			/// <summary>
			/// Int32:层次
			/// </summary>                       
			public int?  Layers {get;set;}   
                         
			/// <summary>
			/// String:编码
			/// </summary>                       
			public string  EnCode {get;set;}   
                         
			/// <summary>
			/// String:名称
			/// </summary>                       
			public string  FullName {get;set;}   
                         
			/// <summary>
			/// String:简称
			/// </summary>                       
			public string  ShortName {get;set;}   
                         
			/// <summary>
			/// String:分类
			/// </summary>                       
			public string  CategoryId {get;set;}   
                         
			/// <summary>
			/// String:负责人
			/// </summary>                       
			public string  ManagerId {get;set;}   
                         
			/// <summary>
			/// String:电话
			/// </summary>                       
			public string  TelePhone {get;set;}   
                         
			/// <summary>
			/// String:手机
			/// </summary>                       
			public string  MobilePhone {get;set;}   
                         
			/// <summary>
			/// String:微信
			/// </summary>                       
			public string  WeChat {get;set;}   
                         
			/// <summary>
			/// String:传真
			/// </summary>                       
			public string  Fax {get;set;}   
                         
			/// <summary>
			/// String:邮箱
			/// </summary>                       
			public string  Email {get;set;}   
                         
			/// <summary>
			/// String:归属区域
			/// </summary>                       
			public string  AreaId {get;set;}   
                         
			/// <summary>
			/// String:联系地址
			/// </summary>                       
			public string  Address {get;set;}   
                         
			/// <summary>
			/// Boolean:允许编辑
			/// </summary>                       
			public bool?  AllowEdit {get;set;}   
                         
			/// <summary>
			/// Boolean:允许删除
			/// </summary>                       
			public bool?  AllowDelete {get;set;}   
                         
			/// <summary>
			/// Int32:排序码
			/// </summary>                       
			public int?  SortCode {get;set;}   
                         
			/// <summary>
			/// Boolean:删除标志
			/// </summary>                       
			public bool?  DeleteMark {get;set;}   
                         
			/// <summary>
			/// Boolean:有效标志
			/// </summary>                       
			public bool?  EnabledMark {get;set;}   
                         
			/// <summary>
			/// String:描述
			/// </summary>                       
			public string  Description {get;set;}   
                         
			/// <summary>
			/// DateTime:创建时间
			/// </summary>                       
			public DateTime?  CreatorTime {get;set;}   
                         
			/// <summary>
			/// String:创建用户
			/// </summary>                       
			public string  CreatorUserId {get;set;}   
                         
			/// <summary>
			/// DateTime:最后修改时间
			/// </summary>                       
			public DateTime?  LastModifyTime {get;set;}   
                         
			/// <summary>
			/// String:最后修改用户
			/// </summary>                       
			public string  LastModifyUserId {get;set;}   
                         
			/// <summary>
			/// DateTime:删除时间
			/// </summary>                       
			public DateTime?  DeleteTime {get;set;}   
                         
			/// <summary>
			/// String:删除用户
			/// </summary>                       
			public string  DeleteUserId {get;set;}   
               
        }    
     }

	//----------Sys_Organize结束----------

	