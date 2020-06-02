using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp2UWP;

namespace StudentManagementApp2UWP.Model
{
    class StudentManagementDBAccess<T> where T : class, new()
    {
        private HttpClientHandler _handler;
        private HttpClient _client;
        private string _url;
        //private const string serverUrl = "http://localhost:44366/"; 
        const string serverUrl = "http://localhost:56934/";

        public StudentManagementDBAccess(string tableUrl)
        {
            _handler = new HttpClientHandler();
            _handler.UseDefaultCredentials = true;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(serverUrl);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _url = tableUrl;
        }

        public async Task<List<T>> GetAll()
        {
            //using (HttpClient client = new HttpClient())
            //{
                try
                {
                    var response = _client.GetAsync(_url).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    List<T> list = JsonConvert.DeserializeObject<List<T>>(data);
                    return list;
                }
                catch (Exception ex)
                {
                    return new List<T>();
                }
            //}
        }

        public void CreateNew(T obj)
        {
            //using (HttpClient client = new HttpClient())
            //{
                //try
                //{
                    string data = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = _client.PostAsync(_url, content).Result;
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string s = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        var statuscode = response.StatusCode;
                    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
            //}
        }

        public void DeleteObject(int id)
        {

            using (_client)
            {
                string url = _url + id;
                try
                {
                    HttpResponseMessage response = _client.DeleteAsync(url).Result;
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateObject(int id, T obj)
        {
            string url = _url + id;
            using (_client)
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(url, content).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
