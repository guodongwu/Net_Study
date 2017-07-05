	//----------Sys_Role开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Role 
        /// </summary>
        [Serializable()]
        public class Sys_Role
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  RoleId {get;set;}   
                         
			/// <summary>
			/// String:角色名
			/// </summary>                       
			public string  Name {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  AddTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  AddIp {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  Status {get;set;}   
                         
			/// <summary>
			/// Byte:
			/// </summary>                       
			public byte?  Order {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Desc {get;set;}   
               
        }    
     }

	//----------Sys_Role结束----------

	