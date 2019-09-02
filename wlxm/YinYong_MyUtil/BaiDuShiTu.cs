using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
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
	            {"probability", "true"}
	        };
            // 数字识别
            var result = client.Numbers(image, options);
            return result;
        }
    }
}
