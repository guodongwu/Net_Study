using System;
using System.Web;

namespace DotNet.Utilities
{
    /// <summary>
    /// 客户端脚本输出
    /// </summary>
    public class JsHelper
    {
        //使用案例
        //string path = AppDomain.CurrentDomain.BaseDirectory + "test.js";
        //string str2 = File.ReadAllText(path);

        //string fun = string.Format(@"sayHello('{0}')" ,this.textBox1.Text.Trim());
        //string result = ExecuteScript(fun, str2);

        //MessageBox.Show(result);


        /// <summary>
        /// 执行JS
        /// </summary>
        /// <param name="sExpression">参数体</param>
        /// <param name="sCode">JavaScript代码的字符串</param>
        /// <returns></returns>
        public static string ExecuteScript(string sExpression, string sCode)
        {
            //Microsoft.CSharp.dll 
            //Microsoft Script Control 1.0
            MSScriptControl.ScriptControl scriptControl = new MSScriptControl.ScriptControl();
            scriptControl.UseSafeSubset = true;
            scriptControl.Language = "JScript";
            scriptControl.AddCode(sCode);
            try
            {
                string str = scriptControl.Eval(sExpression).ToString();
                return str;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return null;
        }

        #region 输出自定义脚本信息
        /// <summary>
        /// 注册脚本块
        /// </summary>
        public static void RegisterScriptBlock(System.Web.UI.Page page, string _ScriptString)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "scriptblock", "<script type='text/javascript'>" + _ScriptString + "</script>");
        }
        #endregion

    }
}