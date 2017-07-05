	//----------Sys_Menu_Function开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Menu_Function 
        /// </summary>
        [Serializable()]
        public class Sys_Menu_Function
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  MFId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  MenuId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  FunctionId {get;set;}   
                         
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
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  IsVisible {get;set;}   
               
        }    
     }

	//----------Sys_Menu_Function结束----------

	