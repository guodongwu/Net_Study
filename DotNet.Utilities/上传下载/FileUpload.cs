using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace DotNet.Utilities
{
    public class FileUpload : IHttpHandler
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.QueryString["method"].ToString();
            switch (method)
            {
                case "ajaxFileUpload":
                    ajaxFileUpload(context);
                    break;
                default:
                    ajaxFileUpload(context);
                    break;
            }
        }
        /// <summary>
        /// function ajaxFileUpLoad() {
        //$.ajaxFileUpload(
        //    {
        //        url: 'Handlers/FileUpload.ashx?method=ajaxFileUpload',
        //        secureuri: false,
        //        fileElementId: 'fileToUpload',
        //        dataType: 'json',
        //        success: function (data, status) {
        //            $('#img1').attr("src", data.imgurl);
        //            if (typeof (data.error) != 'undefined') {
        //                if (data.error != '') {
        //                    alert(data.error);
        //                } else {
        //                    alert(data.msg);
        //                }
        //            }
        //        },
        //        error: function (data, status, e) {
        //            alert(e);
        //        }
        //    }
        //)
        //return false;
        //}
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filePath">上传路径 （若空则需要在config中配置FilePath）</param>
        private static void ajaxFileUpload(HttpContext context, string filePath = null)
        {

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            }
            HttpFileCollection files = context.Request.Files;
            if (files.Count > 0)
            {
                try
                {

                    long mbLength = ConfigHelper.GetConfigInt("maxlen"); //1024 * 1024 * 2;
                    int imgLenth = files[0].ContentLength;//上传图片大小限制
                    if (imgLenth >= mbLength) //上传文件大于1M
                    {
                        string json = "{ error:'fail', msg:'图片大小不能超过2MB,支持JPG,PNG,GIF,BMP格式'}";
                        context.Response.Write(json);
                        context.Response.End();
                        return;
                    }
                    //取出所选文件的本地路径
                    string fullFileName = files[0].FileName;
                    //限定上传文件的格式
                    string type = fullFileName.Substring(fullFileName.LastIndexOf('.') + 1);
                    if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx"
                        || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt"
                        || type == "zip" || type == "rar")
                    {

                    }
                    files[0].SaveAs(filePath + System.IO.Path.GetFileName(files[0].FileName));
                    string res = "{ error:'success', msg:'上传成功!'}";
                    context.Response.Write(res);
                }
                catch (Exception)
                {
                    context.Response.Write("{ error:'fail', msg:'上传失败'}");
                }
            }
            else
            {
                context.Response.Write("{ error:'fail', msg:'没有要上传的文件'}");
            }
            context.Response.End();

        }



        #endregion
    }
}
