using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTide;
using Newtonsoft.Json;

namespace Project
{
    class Project1
    {
        public JSONResponse resp;
        public void WebRequest()
        {
            System.Net.HttpWebRequest ReqRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(string.Format("https://api.stormglass.io/v2/tide/extremes/point?lat=-6.500&lng=112.797"));

            ReqRequest.Method = "GET";
            ReqRequest.Headers.Add("Authorization", "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002");

            //Assign the Response Object of HttpWebRequest to a HttpWebResponse variable
            System.Net.HttpWebResponse ReqResponse = (System.Net.HttpWebResponse)ReqRequest.GetResponse();


            string jsonString;
            using(System.IO.Stream s = ReqResponse.GetResponseStream())
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(s, System.Text.Encoding.UTF8);
                jsonString = sr.ReadToEnd();
            }

            resp = JsonConvert.DeserializeObject<JSONResponse>(jsonString);
            
            Console.WriteLine("Tide Data : " + resp.meta.start + "to" + resp.meta.end);
            foreach (var data in resp.data)
            {
                Console.WriteLine("Height : " + data.height);
                Console.WriteLine("Time   : " + data.time);
                Console.WriteLine("Type   : " + data.type);
            }
        }
    }
}
