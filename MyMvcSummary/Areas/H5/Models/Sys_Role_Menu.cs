	//----------Sys_Role_Menu开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Role_Menu 
        /// </summary>
        [Serializable()]
        public class Sys_Role_Menu
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  RMId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  RoleId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  MenuId {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool?  Status {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  AddTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  AddIp {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  AddUserId {get;set;}   
               
        }    
     }

	//----------Sys_Role_Menu结束----------

	