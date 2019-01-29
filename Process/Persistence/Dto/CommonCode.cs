using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Persistence.Dto
{
    public class CommonCode
    {

        /// <summary>
        /// 根据经纬度获取地理位置
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <returns>具体的地埋位置</returns>
        public static string GetWebRequest(string url)
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync(url).Result;
        }

    }


    public class QryLocation
    {
        public int status { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public Location location { get; set; }
        public string formatted_address { get; set; }
        public string business { get; set; }
        public Addresscomponent addressComponent { get; set; }
        public object[] pois { get; set; }
        public object[] roads { get; set; }
        public object[] poiRegions { get; set; }
        public string sematic_description { get; set; }
        public int cityCode { get; set; }
    }

    public class Location
    {
        public float lng { get; set; }
        public float lat { get; set; }
    }

    public class Addresscomponent
    {
        public string country { get; set; }
        public int country_code { get; set; }
        public string country_code_iso { get; set; }
        public string country_code_iso2 { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public int city_level { get; set; }
        public string district { get; set; }
        public string town { get; set; }
        public string adcode { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
        public string direction { get; set; }
        public string distance { get; set; }
    }

    public class BaiDuXy
    {
        public int error { get; set; }
        public string x { get; set; }
        public string y { get; set; }
    }

}
