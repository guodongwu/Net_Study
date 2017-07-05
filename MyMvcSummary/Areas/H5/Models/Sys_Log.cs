	//----------Sys_Log开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Log 
        /// </summary>
        [Serializable()]
        public class Sys_Log
        {    
		                 
			/// <summary>
			/// Int64:
			/// </summary>                       
			public long  LogId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  UserId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  UserName {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  OperatingType {get;set;}   
                         
			/// <summary>
			/// DateTime:
			/// </summary>                       
			public DateTime  OperatingTime {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  Event {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  OperatingIP {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  MenuId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  MenuName {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  FunctionId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  FunctionName {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  OperatingResult {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  OperatingDesc {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  ProcessName {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  ProcessDesc {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  MethodName {get;set;}   
               
        }    
     }

	//----------Sys_Log结束----------

	