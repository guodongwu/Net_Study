	//----------Sys_Dict开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_Dict 
        /// </summary>
        [Serializable()]
        public class Sys_Dict
        {    
		                 
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int  DictId {get;set;}   
                         
			/// <summary>
			/// Int32:
			/// </summary>                       
			public int?  DictParentId {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  DictName {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  DictKey {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  DictValue {get;set;}   
                         
			/// <summary>
			/// String:
			/// </summary>                       
			public string  DictType {get;set;}   
                         
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
               
        }    
     }

	//----------Sys_Dict结束----------

	