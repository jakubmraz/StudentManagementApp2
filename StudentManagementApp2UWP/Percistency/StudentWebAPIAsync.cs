using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudentManagementApp2WebAPI;

namespace StudentManagementApp2UWP.Percistency
{
    class StudentWebAPIAsync<T> where T:class, new()
    {
        HttpClientHandler handler;
        HttpClient client;
        string _url;
        const string serverURL = "http://localhost:56934/";


        public StudentWebAPIAsync( string url)
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true; // to make sure that the default credential are sent by the request
                                                  // below we r going to create our Http client inside a using statement
            client = new HttpClient(handler);
            client.BaseAddress = new Uri(serverURL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _url = url;
        }

        public List<T> GetAll() 
        {
            using (client)
            {

                try
                {
                    string s = _url;
                    var response = client.GetAsync(_url).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                    List<T> cList = JsonConvert.DeserializeObject<List<T>>(data);
                    return cList;
                }

                catch (Exception ex)
                {
                    return new List<T>();
                }
            }

        }

        public async void CreateNewOne(T obj)
        {
            using (client)
            {
                try
                {
                    string data = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(_url, content);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public async Task<T> DeleteOne(int id)
        {
            using (client)
            {
                try
                {
                    string d_url = _url + id;
                    var response =   client.DeleteAsync(d_url).Result;
                    response.EnsureSuccessStatusCode();
                    string data = response.Content.ReadAsStringAsync().Result;
                   return JsonConvert.DeserializeObject<T>(data);
                }
                catch (Exception ex)
                {
                    return new T();
                }
            }
        }


    }
}
