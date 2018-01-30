using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Bll.Network
{
    public static class Network
    {
        public static string GetRequest(string baseAdress, string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAdress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = "";
            HttpResponseMessage response = client.GetAsync(url).Result;
            result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public static string PostRequest(string baseAdress, string url, string body)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAdress);
            var contentData = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, contentData).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}