using Grpc.Core;
using LowCode.Helper;
using LowCode.IService;
using LowCode.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace LowCode.Service
{
    public class FaceService : Volo.Abp.Application.Services.ApplicationService
    {


        // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
        // 返回token示例
        public static String TOKEN = "24.adda70c11b9786206253ddb70affdc46.2592000.1493524354.282335-1234567";

        // 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
        private static String clientId = "cINhrevuuEnCGUNRG3BN2g5e";
        // 百度云中开通对应服务应用的 Secret Key
        private static String clientSecret = "1Izae8ckxoGzsdrdT5I3k1R3ig3lR2VQ";

        [HttpPost]
        public String getAccessToken()
        {
            String authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", clientId));
            paraList.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            String result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }


        //图片转换 Base64
        public string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //人脸注册
        public string FaceAdd(string Access_token)
        {
            string host = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add?access_token=" + Access_token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            string p1 = ImgToBase64String(@"C:\Users\HUAWEI\Desktop\srvsetwp\3.jpg");
            String str = "{\"image\":\"" + p1 + "\",\"image_type\":\"BASE64\",\"group_id\":\"group_repeat\",\"user_id\":\"user1\",\"user_info\":\"abc\",\"quality_control\":\"LOW\",\"liveness_control\":\"NORMAL\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }

        

        // 人脸对比
        public string faceMatch(Parameter parameter)
        {

            string host = "https://aip.baidubce.com/rest/2.0/face/v3/match?access_token=" + parameter.token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;

            string p1 = ImgToBase64String(@"C:\Users\HUAWEI\Desktop\srvsetwp\5.jpg");

           
            

            //string p2 = ImgToBase64String(picture);

            //C:\Users\HUAWEI\Desktop\srvsetwp\4.jpg
            String str = "[{\"image\": \"" + parameter.picture + "\", \"image_type\": \"BASE64\", \"face_type\": \"LIVE\", \"quality_control\": \"LOW\"},{\"image\": \"" + p1 + "\", \"image_type\": \"BASE64\", \"face_type\": \"IDCARD\", \"quality_control\": \"LOW\"}]";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();

            return result;
        }


        


    }

    public class Parameter
    {
        public string token { get; set; }
        public string picture { get; set; }

    }
}
