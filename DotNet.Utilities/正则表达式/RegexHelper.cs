using System;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// 操作正则表达式的公共类
    /// </summary>    
    public class RegexHelper
    {
        #region 验证输入字符串是否与模式字符串匹配
        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件</param>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        #endregion
        /// <summary>
        /// 判断中文 包括点
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isHasDot">是否包含点</param>
        /// <returns></returns>
        public static bool IsChinese(string text, bool isHasDot = false)
        {
            //"^[\u4e00-\u9fa5]+$"

            string pattern = "^[\u4e00-\u9fa5]+$";
            if (isHasDot)
                pattern = "^[\u4e00-\u9fa5]+(·[\u4e00-\u9fa5]+)*$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(text);

        }
        /// <summary>
        /// 邮箱验证
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsEmail(string text)
        {
            //    /^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$/i
            string pattern = @"(?i)^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(text);


        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsPhone(string text)
        {
            Regex reg = new Regex(@"^[1][3-8]+\\d{9}");
            return reg.IsMatch(text);

        }

        #region 身份证号码验证

        /// <summary>
        /// 验证身份证号码
        /// </summary>
        /// <param name="Id">身份证号码</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证18位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 验证15位身份证号
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        /// <summary>
        /// IP地址
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string text)
        {
            Regex reg = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
            return reg.IsMatch(text);

        }


        /// <summary>
        /// 匹配url 包括端口号或者ip
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsURL(string text)
        {
            Regex reg = new Regex(@"(?i)((http|ftp|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?");
            return reg.IsMatch(text);
        }
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsPwd(string text)
        {
            // 6-20 位，字母、数字、字符
            //String reg = "^([A-Z]|[a-z]|[0-9]|[`-=[];,./~!@#$%^*()_+}{:?]){6,20}$";
            Regex reg = new Regex("^([A-Z]|[a-z]|[0-9]|[`~!@#$%^&*()+=|{}':;',\\\\[\\\\].<>/?~！@#￥%……&*（）——+|{}【】‘；：”“’。，、？]){6,20}$");
            return reg.IsMatch(text);
        }
        /// <summary>
        /// 验证密码强度
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CheckSecurity(string text)
        {
            return Regex.Replace(text, "^(?:([a-z])|([A-Z])|([0-9])|(.)){6,}|(.)+$", "$1$2$3$4$5").Length;
        }
        public static bool IsNick(string text)
        {
            // 昵称格式：限16个字符，支持中英文、数字、减号或下划线
            Regex reg = new Regex("^[\\u4e00-\\u9fa5_a-zA-Z0-9-]{1,16}$");
            return reg.IsMatch(text);
        }
        /// <summary>
        /// 货币 可以为负数
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isHasComma"></param>
        /// <param name="positive"></param>
        /// <returns></returns>
        public static bool IsMoney(string text, bool isHasComma = false)
        {

            string pattern = @"((^[-]?([1-9]\d*))|^0)(\.\d{1,2})?$|(^[-]0\.\d{1,2}$)";

            if (isHasComma)
            {
                pattern = @"(^[-]?[1-9]\d{0,2}($|(\,\d{3})*($|(\.\d{1,2}$))))|((^[0](\.\d{1,2})?)|(^[-][0]\.\d{1,2}))$";
            }
            Regex reg = new Regex(pattern);
            return reg.IsMatch(text);

        }
        /// <summary>
        /// 货币
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsMoney(string text)
        {
            if (text.IndexOf(',') > -1)
            {
                return IsMoney(text, true);
            }
            return IsMoney(text);
        }
        /// <summary>
        /// 针对正的
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isHasComma"></param>
        /// <returns></returns>
        public static bool IsMoneyPlus(string text, bool isHasComma = false)
        {
            string pattern = @"((^([1-9]\d*))|^0)(\.\d{1,2})?$|(^[-]0\.\d{1,2}$)";

            if (isHasComma)
            {
                pattern = @"(^[1-9]\d{0,2}($|(\,\d{3})*($|(\.\d{1,2}$))))|((^[0](\.\d{1,2})?)|(^[-][0]\.\d{1,2}))$";
            }
            Regex reg = new Regex(pattern);
            return reg.IsMatch(text);
        }

        /// <summary>
        /// 货币
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsMoneyPlus(string text)
        {
            if (text.IndexOf(',') > -1)
            {
                return IsMoney(text, true);
            }
            return IsMoneyPlus(text);
        }

        #region 检测客户的输入中是否有危险字符串
        /// <summary>
        /// 检测客户输入的字符串是否有效,并将原始字符串修改为有效字符串或空字符串。
        /// 当检测到客户的输入中有攻击性危险字符串,则返回false,有效返回true。
        /// </summary>
        /// <param name="input">要检测的字符串</param>
        public static bool IsValidInput(ref string input)
        {
            try
            {
                if (IsNullOrEmpty(input))
                {
                    //如果是空值,则跳出
                    return true;
                }
                else
                {
                    //替换单引号
                    input = input.Replace("'", "''").Trim();

                    //检测攻击性危险字符串
                    string testString = "and |or |exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
                    string[] testArray = testString.Split('|');
                    foreach (string testStr in testArray)
                    {
                        if (input.ToLower().IndexOf(testStr) != -1)
                        {
                            //检测到攻击字符串,清空传入的值
                            input = "";
                            return false;
                        }
                    }

                    //未检测到攻击字符串
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        #endregion

        #region 判断对象是否为空
        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <typeparam name="T">要验证的对象的类型</typeparam>
        /// <param name="data">要验证的对象</param>        
        public static bool IsNullOrEmpty<T>(T data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }

        /// <summary>
        /// 判断对象是否为空，为空返回true
        /// </summary>
        /// <param name="data">要验证的对象</param>
        public static bool IsNullOrEmpty(object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        #endregion
    }
}
