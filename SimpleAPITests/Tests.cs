using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SimpleAPITests
{
    
[TestFixture]
public class Tests
{
    public async Task<string> Post(string path, int data)
    {
        using (var client = new HttpClient())
        {
            client.Timeout = new TimeSpan(0, 0, 5);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response_message = await client.PostAsync("http://localhost:5000/api/" + path, new StringContent("{\"year\":" + data + "}", Encoding.UTF8, "application/json"));

            var response = await response_message.Content.ReadAsStringAsync();
            if (response_message.IsSuccessStatusCode)
            {
                return response;
            }
            Console.WriteLine(response);
            throw new Exception("Request failed");
        }
    }
    
    [Test]
    public void Test1()
    {
        //var parameters = new Years(1);
        Task.Run( () =>
        {
            var output = Post("years/", 1);
            Console.WriteLine(output.Result);
        }).Wait();
        
        Assert.True(true);
    }
}

}