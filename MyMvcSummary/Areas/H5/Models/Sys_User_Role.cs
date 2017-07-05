	//----------Sys_User_Role开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_User_Role 
        /// </summary>
        [Serializable()]
        public class Sys_User_Role
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  URId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  UserId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  RoleId {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  Status {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  AddTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  AddIP {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Description {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  AddUserId {get;set;}   
               
        }    
     }

	//----------Sys_User_Role结束----------

	