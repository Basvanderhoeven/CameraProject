using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLI_Cameras
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var baseAPIurl = "http://localhost:50674/api/Cameras";

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "--name":
                        if (i + 1 <= args.Length)
                        {
                            baseAPIurl += "/name/" + args[i + 1];
                        }
                        break;
                };
            }
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(baseAPIurl).GetAwaiter().GetResult();
                    var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        List<Camera> cameras = JsonConvert.DeserializeObject<List<Camera>>(result.ToString());
                        foreach (Camera camera in cameras)
                        {
                            Console.WriteLine(camera.Number.ToString() + "|" + camera.Description + "|" + camera.Latitude.ToString() + "|" + camera.Longitude.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
