	//----------Sys_Menu开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Menu 
        /// </summary>
        [Serializable()]
        public class Sys_Menu
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  MenuId {get;set;}   
                         
			/// <summary>
			/// String:菜单名
			/// </summary>                       
			public string  Name {get;set;}   
                         
			/// <summary>
			/// Byte:类型
			/// </summary>                       
			public byte?  Type {get;set;}   
                         
			/// <summary>
			/// String:地址
			/// </summary>                       
			public string  Url {get;set;}   
                         
			/// <summary>
			/// String:图标
			/// </summary>                       
			public string  Icon {get;set;}   
                         
			/// <summary>
			/// Byte:排序
			/// </summary>                       
			public byte?  Sort {get;set;}   
                         
			/// <summary>
			/// Int32:上级菜单
			/// </summary>                       
			public int  ParentMenuId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  MenuController {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  isVisible {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  isMenu {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool?  isLeaf {get;set;}   
               
        }    
     }

	//----------Sys_Menu结束----------

	