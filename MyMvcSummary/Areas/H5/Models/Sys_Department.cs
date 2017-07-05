	//----------Sys_Department开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Department 
        /// </summary>
        [Serializable()]
        public class Sys_Department
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  DeptId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  DeptName {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  DeptDesc {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  ParentId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  AddUserId {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  AddDate {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool?  IsVisible {get;set;}   
               
        }    
     }

	//----------Sys_Department结束----------

	