using Microsoft.VisualBasic.Devices;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Movease.Controllers
{
    public class MovieController : ApiController
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            Task<HttpResponseMessage> getTask = httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc");

            HttpResponseMessage response = getTask.Result;

            HttpResponseMessage getResponse = httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Mouse movieResponse = response.Content.ReadAsAsync<Movie>().Result;
            }
        }
    }
}
