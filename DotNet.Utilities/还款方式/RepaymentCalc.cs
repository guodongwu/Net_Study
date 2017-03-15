using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNet.Utilities
{
    public class RepaymentCalc
    {
        /// <summary>
        /// 等额本息还款法
        /// 指在贷款期内每月以相等的额度平均偿还贷款本息。
        /// 计算公式为：每月还款额=月利率×（1+月利率）还款期数/（1+月利率）还款期数-1X贷款本金
        /// 遇到利率调整及提前还款时，应根据未偿还贷款余额和剩余还款期数调整公式，并计算每期还款额。
        /// </summary>
        public class DengEBenXi
        {
            /// <summary>
            /// 等额本息法
            /// </summary>
            /// <param name="amountT">投资金额</param>
            /// <param name="yearRate">年利率</param>
            /// <param name="monthsx">投资期限，单位：月</param>
            /// <returns></returns>
            public static List<BackUnit> Compute(double amount, double yearRate, int months)
            {
                var datalist = new List<BackUnit>();  //new Array(Deadline);     /
                double[][] arr = new double[3][];//声明交错数组

                int i;
                double tlnAcct = 0, tdepAcct = 0;
                double[] lnAcctbal = new double[months]; /*贷款余额*/
                double[] depAcctbal = new double[months]; /*总还款*/
                double[] payrateAcct = new double[months]; /*每月应还利息*/
                double[] payAcct = new double[months]; /*每月应还款*/
                double[] paybaseAcct = new double[months]; /*每月应还本金*/

                tlnAcct = amount;

                for (i = 0; i < months; i++)
                {
                    var unit = new BackUnit();
                    paybaseAcct[i] = (Math.Pow((1 + yearRate / 12), i + 1) - Math.Pow((1 + yearRate / 12), i)) / (Math.Pow((1 + yearRate / 12), months) - 1) * amount;
                    payrateAcct[i] = tlnAcct * yearRate / 12;
                    payAcct[i] = paybaseAcct[0] + payrateAcct[0];
                    lnAcctbal[i] = tlnAcct - paybaseAcct[i];
                    depAcctbal[i] = tdepAcct + payAcct[i];
                    tdepAcct = depAcctbal[i];
                    if (i == months - 1)
                        tlnAcct = 0;
                    else
                        tlnAcct = tlnAcct - paybaseAcct[i];
                    unit.Number = (i + 1);
                    unit.A = Math.Round(payAcct[i], 2);
                    unit.C = Math.Round(paybaseAcct[i], 2);
                    unit.B = Math.Round(payrateAcct[i], 2);
                    unit.D = Math.Round(lnAcctbal[i], 2);
                    datalist.Add(unit);
                }

                arr[0] = payAcct;//月还款
                arr[1] = paybaseAcct;//月本金
                arr[2] = payrateAcct;//月利息

                return datalist;
            }


        }
        /// <summary>
        ///按月付息到期还本
        ///先息后本法又称期末清偿法，
        ///指借款人在贷款到期日还清贷款本息，
        ///每月偿还利息。
        ///一般适用于期限在1年以内（含1年）的贷款。
        /// </summary>
        public class AnYueFuxiDaoqiHuanBen
        {
            /// <summary>
            /// 按月付息到期还本
            /// </summary>
            /// <param name="amount">投资金额</param>
            /// <param name="yearRate">年利率</param>
            /// <param name="months">投资期限，单位：月</param>
            /// <returns></returns>
            public static List<BackUnit> Compute(double amount, double yearRate, int months)
            {
                var datalist = new List<BackUnit>();  //new Array(Deadline);     //
                var rateIncome = amount * yearRate * (months / 12);
                var rateIncomeEve = (rateIncome / months);
                var total = amount + rateIncome;
                for (var i = 1; i < months; i++)
                {
                    var unit = new BackUnit();
                    unit.Number = i;// 期数
                    unit.TotalRate = Math.Round(rateIncome, 2);//Math.Round((Amount + TotalRate) * 100) / 100;// 总利息
                    unit.TotalMoney = Math.Round(total, 2);//TotalRate;// 总还款
                    unit.A = Math.Round(rateIncomeEve, 2);// 偿还本息  someNumber.ToString("N2");
                    unit.B = Math.Round(rateIncomeEve, 2);// 偿还利息
                    unit.C = 0;// 偿还本金
                    unit.D = amount;
                    datalist.Add(unit);
                }
                datalist.Add(new BackUnit()
                {
                    Number = months,
                    TotalRate = rateIncome,
                    TotalMoney = total,
                    A = Math.Round(amount + rateIncomeEve, 2),
                    B = Math.Round(rateIncomeEve, 2),
                    C = amount,
                    D = 0
                });
                return datalist;
            }
        }
        /// <summary>
        /// 一次性还本付息
        /// </summary>
        public class YicixingHuanBenFuxi
        {
            /// <summary>
            /// 一次性还本付息
            /// </summary>
            /// <param name="amount">投资金额</param>
            /// <param name="yearRate">年利率</param>
            /// <param name="months">投资期限，单位：月</param>
            /// <returns></returns>
            public static List<BackUnit> Compute(double amount, double yearRate, int months)
            {
                var datalist = new List<BackUnit>();
                BackUnit unit = new BackUnit();
                var rate = yearRate;
                var rateIncome = amount * rate * (months / 12);
                var totalIncome = amount + rateIncome;
                unit.Number = 1;// 期数
                unit.TotalRate = rateIncome;//Math.Round((Amount + TotalRate) * 100) / 100;// 总利息
                unit.TotalMoney = totalIncome;//TotalRate;// 总还款
                unit.A = totalIncome;// 偿还本息  someNumber.ToString("N2");
                unit.B = rateIncome;// 偿还利息
                unit.C = 0;// 偿还本金
                unit.D = 0;// 剩余本金 
                datalist.Add(unit);
                return datalist;
            }
        }

        public class BackUnit
        {

            /// <summary>
            /// 当前期数
            /// </summary>
            public int Number { get; set; }

            /// <summary>
            /// 总利息
            /// </summary>

            public double TotalRate { get; set; }
            /// <summary>
            ///总还款
            /// </summary>
            public double TotalMoney { get; set; }
            /// <summary>
            /// 本期应还全部
            /// </summary>
            public double A { get; set; }
            /// <summary>
            /// 本期应还利息
            /// </summary>
            public double B { get; set; }
            /// <summary>
            /// 本期应还本金
            /// </summary>
            public double C { get; set; }
            /// <summary>
            /// 本期剩余本金
            /// </summary>
            public double D { get; set; }
        }

        /// <summary>
        /// 等额本金还款法指在贷款期内每月等额偿还贷款本金，贷款利息随本金逐月递减。
        /// 特点是定期、定额还本，每月付款及每月贷余额定额减少。
        /// 计算公式为：每月还款额=贷款本金/还款期数+（贷款本金-已归还货款本金累计额）×月利率
        /// </summary>
        public class DenEBenJin
        {

            /// <summary>
            /// 方式：等本金还款
            /// </summary>
            /// <param name="nDeadline">期限</param>
            /// <param name="fMoney">总金额</param>
            /// <param name="dRate">年利率</param>
            /// <returns>交错数组:(1.月还款额,2.月利息)</returns>
            public static List<BackUnit> Compute(double amount, double yearRate, int months)
            {

                var datalist = new List<BackUnit>();
                double[][] arr = new double[2][];//声明交错数组

                double[] fPrincipal = new double[months]; //本金
                double[] fSparePrin = new double[months];//剩余本金
                double[] fMonthRate = new double[months];//月利息
                double[] fMonthMoney = new double[months];//月还款额
                for (int i = 0; i < months; i++)
                {
                    var unit = new BackUnit();
                    unit.Number = i + 1;
                    fPrincipal[i] = amount / months;
                    unit.C = Math.Round(fPrincipal[i], 2);
                    if (i == 0)
                    {
                        fSparePrin[i] = Math.Round(amount - fPrincipal[i], 2);//剩余本金
                        fMonthRate[i] = Math.Round(amount * (yearRate / 12), 2);//月利息
                        fMonthMoney[i] = Math.Round(fPrincipal[i] + amount * (yearRate / 12), 2);

                    }
                    else
                    {
                        if (i == (months - 1))
                            fSparePrin[i] = 0;

                        else
                            fSparePrin[i] = Math.Round(amount - (amount / months) * (i + 1), 2);//        Math.Round(fSparePrin[i - 1] - fPrincipal[i], 2);//剩余本金
                        fMonthRate[i] = Math.Round(fSparePrin[i - 1] * (yearRate / 12), 2);//月利息=上个月的剩余本金×利率
                        fMonthMoney[i] = Math.Round(fPrincipal[i] + (fSparePrin[i - 1] * (yearRate / 12)), 2);
                    }
                    unit.B = fMonthRate[i];
                    unit.A = fMonthMoney[i];
                    unit.D = fSparePrin[i];
                    datalist.Add(unit);
                }

                //arr[0] = fMonthMoney;//月还款
                //arr[1] = fMonthRate;//月利息
                return datalist;
            }
        }

    }
}