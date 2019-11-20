using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using xDM;
namespace MyUtil
{
    public class BaiDuShiTu
    {
        public JObject GeneralBasic(string path)
        {
            string apikey = "hUqtyvI4ip03GS8ehcpI3hRX";
            string secretkey = "DIM7drbNHoGlhLXjD7AMf9uD3bYlSNhN";
            var client = new Baidu.Aip.Ocr.Ocr(apikey, secretkey);
            client.Timeout = 60000;  // 修改超时时间
            var image = File.ReadAllBytes(path);
            var options = new Dictionary<string, object>{
	            {"language_type", "CHN_ENG"},
	            {"detect_direction", "true"},
	            {"detect_language", "true"},
	            {"probability", "true"}
	        };
            // 通用文字识别 高精度AccurateBasic option 不包含 lanuage detect language
            var result = client.GeneralBasic(image, options);
            return result;
        }

        public JObject Number(string path)
        {
            string apikey = "hUqtyvI4ip03GS8ehcpI3hRX";
            string secretkey = "DIM7drbNHoGlhLXjD7AMf9uD3bYlSNhN";
            var client = new Baidu.Aip.Ocr.Ocr(apikey, secretkey);
            client.Timeout = 60000;  // 修改超时时间
            var image = File.ReadAllBytes(path);
            var options = new Dictionary<string, object>{
	            //{"language_type", "CHN_ENG"},
	            {"detect_direction", "true"},
	            //{"detect_language", "true"},
	            //{"probability", "true"}
	        };
            // 数字识别
            var result = client.Numbers(image, options);
            return result;
        }

        public string wenzishibie(int ind, string path)
        {
            WriteLog.WriteLogFile(ind + "", "进入到文字识别");
            JObject rs = GeneralBasic(path);
            if (rs.Root["words_result"] == null)
            {
                return null;
            }
            var txts = (from obj in (JArray)rs.Root["words_result"]
                        select (string)obj["words"]);
            string rt = "";
            foreach (var r in txts)
            {
                if (r != null)
                {
                    string ar = r.Trim();
                    if (!ar.Equals(""))
                    {
                        WriteLog.WriteLogFile(ind + "", "识别出的" + ar + "--" + ar.Equals(""));
                        rt = r;
                        break;
                    }
                }
            }
            return rt;

        }

        public string quwenzifrombaidu(myDm mf,int dqinx, int jubing, int x1, int y1, int x2, int y2)
        {
            WriteLog.WriteLogFile(dqinx + "", "先截图再取文字");
            string qushu = "";
            string filename = dqinx + "_" + mf.GetTime() + ".bmp";
            mf.captureBmpFeiXianDing(jubing, @"d:\mypic_save\", filename, x1, y1, x2, y2);
            if (mf.IsFileExist(@"d:\mypic_save\" + filename) == 1)
            {
                WriteLog.WriteLogFile(dqinx + "", "截图保存成功,再取文字");
                string r = wenzishibie(dqinx, @"d:\mypic_save\" + filename);
                if (r != null && r != "")
                {
                    qushu = r;
                    WriteLog.WriteLogFile(dqinx + "", " 文字识别的结果" + qushu);
                }
            }
            return qushu;
        }

        public string shuzishibie(int ind, string path)
        {
            WriteLog.WriteLogFile(ind + "", "进入到数字识别");            
            JObject rs = Number(path);
            if (rs.Root["words_result"] == null)
            {
                return null;
            }
            var txts = (from obj in (JArray)rs.Root["words_result"]
                        select (string)obj["words"]);
            string rt = "";
            foreach (var r in txts)
            {
                if (r != null)
                {
                    string ar = r.Trim();
                    if (!ar.Equals(""))
                    {
                        WriteLog.WriteLogFile(ind + "", "识别出的" + ar + "--" + ar.Equals(""));
                        rt = r;
                        break;
                    }
                }
            }
            int a = -1;
            try { a = int.Parse(rt); }
            catch (Exception e)
            {
                WriteLog.WriteLogFile(ind + "", "数字转换出错" + e.Message); a = -1;
                throw e;
            }
            return a + "";

        }


        public int qushufrombaidu(myDm mf, int dqinx, int jubing, int x1, int y1, int x2, int y2)
        {
            WriteLog.WriteLogFile(dqinx+"", "先截图再取数");
            int qushu = -1;
            string filename = dqinx + "_" + mf.GetTime() + ".bmp";
            mf.captureBmpFeiXianDing(jubing, @"d:\mypic_save\", filename, x1, y1, x2, y2);
            if (mf.IsFileExist(@"d:\mypic_save\" + filename) == 1)
            {
                string r = wenzishibie(dqinx, @"d:\mypic_save\" + filename);
                if (r != null && r != "")
                {
                    qushu = int.Parse(r);
                    WriteLog.WriteLogFile(dqinx + "", " 普通取数的结果" + qushu);
                }
            }
            return qushu;
        }

        public int qushufrombaidu_gaoqing(myDm mf, int dqinx, int jubing, int x1, int y1, int x2w, int y2h)
        {
            WriteLog.WriteLogFile(dqinx + "","先截图再取数gaoqing");
            int qushu = -1;
            string timestamp = mf.GetTime() + "";
            string mydir1 = @"d:\mypic_save\" + timestamp + ".png";
            MyLdcmd.myScreencap(dqinx, mydir1);
            System.Drawing.Bitmap f = MyFuncUtil.ReadImageFile(mydir1);
            if (f != null)
            {
                System.Drawing.Bitmap g = MyFuncUtil.KiCut(f, x1, y1, x2w, y2h);
                g.Save(@"d:\mypic_save\" + timestamp + "_1.jpg");
                g.Dispose();
            }
            if (File.Exists(@"d:\mypic_save\" + timestamp + "_1.jpg"))
            {
                string r = shuzishibie(dqinx, @"d:\mypic_save\" + timestamp + "_1.jpg");
                if (r != null && r != "")
                {
                    qushu = int.Parse(r);
                    WriteLog.WriteLogFile(dqinx + "", " 高清取数的结果" + qushu);
                }
            }
            return qushu;
        }

        public string quwenzifromyanzhengma(myDm mf, int dqinx, int jubing, string datileixing,int x1, int y1, int x2, int y2)
        {
            WriteLog.WriteLogFile(dqinx + "", "先截图再取搞验证码");
            string qushu = "";
            string filename = dqinx + "_" + mf.GetTime() + ".bmp";
            mf.captureBmpFeiXianDing(jubing, @"d:\mypic_save\", filename, x1, y1, x2, y2);
            if (mf.IsFileExist(@"d:\mypic_save\" + filename) == 1)
            {
                WriteLog.WriteLogFile(dqinx + "", "截图保存成功,再取验证码");
                YanZhengMa yzm = new YanZhengMa();
                string getyzm = yzm.getYanZhengMa(@"d:\mypic_save\" + filename,datileixing);
                if (getyzm != null && getyzm != "")
                {
                    qushu = getyzm;
                    WriteLog.WriteLogFile(dqinx + "", "验证码结果" + qushu);
                }
            }
            return qushu;
        }
    }
}
