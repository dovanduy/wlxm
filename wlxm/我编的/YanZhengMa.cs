using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace MyUtil
{
    public class YanZhengMa
    {
        /// <summary>
        /// 测试验证码图片
        /// </summary>
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern int SendFileEx(string MyUserStr, string GameID, string FilePath, int TimeOut, int LostPoint, string BeiZhu, StringBuilder retTid, StringBuilder retStr);
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern int SendFile(string MyUserStr, string GameID, string FilePath, int TimeOut, int LostPoint, string BeiZhu, StringBuilder retStr);
        //[DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        //public static extern int SendByteEx(string MyUserStr, string GameID, byte* PicBytes, int lenBytes, int TimeOut, int LostPoint, string BeiZhu, StringBuilder retTid, StringBuilder retStr);
        //[DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        //public static extern int SendByte(string MyUserStr, string GameID, byte* PicBytes, int lenBytes, int TimeOut, int LostPoint, string BeiZhu, StringBuilder retStr);
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern bool IsRight(string Response);
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern void SetRebate(string partnerID);
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern int SetQuality(int Quality);
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern int SendError(string ID, StringBuilder retStr);
        [DllImport("haoi.dll")] //字符串写的是 DLL 所在目录，支持相对路径，默认是程序的跟目录（文件夹）
        public static extern int GetAnswer(string id, StringBuilder retStr);

        [DllImport("haoi.dll")]
        public static extern int GetPoint(string MyUserStr, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int RegID(string MyId, string MyPass, string MyEmail, string MyQQ, string From, int IsSon, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int Login(string Id, string Pass, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int Pay(string Id, string Card, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int UseKey(string Id, string Keys, int Point, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int CheckKey(string Id, string Keys, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int KeyEndDate(string Id, string Keys, StringBuilder retStr);
        [DllImport("haoi.dll")]
        public static extern int WriteWordtoJPG(string FilePath, string PicWH, string XYWrods, int Size, string RGBcolor);


        public string getYanZhengMa(string path)
        {
            StringBuilder sb = new StringBuilder(512);
            var ans = SendFile("renzhida|0FFD4CA59A44C9E1", "X3004", path, 300, 0, "", sb);//@"c:\mypic_save\2_653355203.bmp"

            var TID = sb.ToString();
            StringBuilder Reply = new StringBuilder(512);
            if (IsRight(TID))
            {
                
                for (int i = 0; i < 999; i++)
                {
                    Thread.Sleep(1000);
                    GetAnswer(TID, Reply);
                    if (Reply.ToString() != "")
                    {
                        WriteLog.WriteLogFile("", Reply.ToString() + "Reply1");
                        break;
                        //跳出FOR循环
                    }

                }//end for



                if (IsRight(Reply.ToString()))
                {
                    WriteLog.WriteLogFile("", Reply.ToString() + "Reply2");

                }
                else
                {
                    if (Reply.ToString() == "#编号不存在") { } // 应检查网络后 重新发送（原因：我们数据在一小段时间里会转移数据 如果您的网络质量不好 或者一直发送总会遇到编号不存在的情况）
                    if (Reply.ToString() == "#答案不确定") { } // 应换验证码后 重新发送(答案不确定是会返回题分的)
                    if (Reply.ToString() == "#超时") { } // 应重新发送(超时是会返回题分的，这个超时是指的在您规定的时间内 没有返回答案)
                    if (Reply.ToString() == "#网络错误") { } // 应重新发送
                    WriteLog.WriteLogFile("", Reply.ToString() + "Reply3");
                }

            }
            else
            {
                if (TID.ToString() == "") { } // 应检查网络后 重新发送（原因：我们的函数有10-15秒的超时 如果请求在规定时间内没有完成 函数则会返回空）
                if (TID.ToString() == "#验证码错") { } // 应调用SendError 后再重新发送（原因：返回的验证码小于设置的最小位数）
                if (TID.ToString() == "#图片过小") { } // 应确认图片截图没问题后 再重新发送（原因：您的截图出了问题）
                if (TID.ToString() == "#密码串有误") { } // 应提示用户
                if (TID.ToString() == "#GameID不存在") { } // 应提示用户
                if (TID.ToString() == "#题分不足") { } // 应提示用户
                if (TID.ToString() == "#网络错误") { } // 应重新发送
                WriteLog.WriteLogFile("", TID.ToString() + "TID");
            }
            return Reply.ToString();
        }
    }
}
