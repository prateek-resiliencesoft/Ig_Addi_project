using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Social_Media_Service_Panel.Helper
{
    public class HttpCalls
    {
        public JObject HttpJsonwebrequests(string uri, string HTTPMethod)
        {


            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(uri);
            Request.Method = HTTPMethod;
            Request.Timeout = 300000;
            //Request.CookieContainer = new CookieContainer();
            StreamReader readStream;
            Request.MaximumAutomaticRedirections = 4;
            Request.MaximumResponseHeadersLength = 4;
            Request.ContentLength = 0;
            HttpWebResponse Response;
            string strResponse = "";
            JObject objJson = null;
            try
            {
                Response = (HttpWebResponse)Request.GetResponse();
                Stream receiveStream = Response.GetResponseStream();
                readStream = new StreamReader(receiveStream);
                strResponse = readStream.ReadToEnd();
                Response.Close();
                readStream.Close();
                objJson = JObject.Parse(strResponse);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // strResponse = ex.Message;
                //Logger.LogText("Exception from Twitter:" + ex.Message,"");               
            }
            return objJson;
            //return strResponse;
        }

        public string Httpwebrequests(string uri, string HTTPMethod)
        {


            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(uri);
            Request.Method = HTTPMethod;
            Request.Timeout = 300000;
            //Request.CookieContainer = new CookieContainer();
            StreamReader readStream;
            Request.MaximumAutomaticRedirections = 4;
            Request.MaximumResponseHeadersLength = 4;
            Request.ContentLength = 0;
            HttpWebResponse Response;
            string strResponse = "";
            try
            {
                Response = (HttpWebResponse)Request.GetResponse();
                Stream receiveStream = Response.GetResponseStream();
                readStream = new StreamReader(receiveStream);
                strResponse = readStream.ReadToEnd();
                Response.Close();
                readStream.Close();
                JObject objJson = JObject.Parse(strResponse);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // strResponse = ex.Message;
                //Logger.LogText("Exception from Twitter:" + ex.Message,"");               
            }
            //return objJson;
            return strResponse;
        }
    }
}