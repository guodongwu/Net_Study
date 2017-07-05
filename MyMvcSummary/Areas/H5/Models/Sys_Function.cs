	//----------Sys_Function开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Function 
        /// </summary>
        [Serializable()]
        public class Sys_Function
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  FunctionId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  ControllerName {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  ActionName {get;set;}   
                         
			/// <summary>
			/// String:功能名称
			/// </summary>                       
			public string  Name {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Description {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  AddUserId {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime?  AddTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  AddIp {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Icon {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  IsVisible {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool?  IsButton {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  ParentFID {get;set;}   
                         
			/// <summary>
			/// Byte:
			/// </summary>                       
			public byte?  Sort {get;set;}   
                         
			/// <summary>
			/// Boolean:
			/// </summary>                       
			public bool  Status {get;set;}   
               
        }    
     }

	//----------Sys_Function结束----------

	