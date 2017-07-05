	//----------Sys_DbBackup开始----------
    
	using System;
	using System.Collections.Generic;
	namespace MyProject.Entities 
	{
        /// <summary>
        /// 数据表实体类：Sys_DbBackup 
        /// </summary>
        [Serializable()]
        public class Sys_DbBackup
        {    
		                 
			/// <summary>
			/// Int32:备份主键
			/// </summary>                       
			public int  BackupId {get;set;}   
                         
			/// <summary>
			/// String:备份类型
			/// </summary>                       
			public string  BackupType {get;set;}   
                         
			/// <summary>
			/// String:数据库名称
			/// </summary>                       
			public string  DbName {get;set;}   
                         
			/// <summary>
			/// String:文件名称
			/// </summary>                       
			public string  FileName {get;set;}   
                         
			/// <summary>
			/// String:文件大小
			/// </summary>                       
			public string  FileSize {get;set;}   
                         
			/// <summary>
			/// String:文件路径
			/// </summary>                       
			public string  FilePath {get;set;}   
                         
			/// <summary>
			/// DateTime:备份时间
			/// </summary>                       
			public DateTime?  BackupTime {get;set;}   
                         
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

	//----------Sys_DbBackup结束----------

	