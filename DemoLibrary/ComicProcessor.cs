using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public static class ComicProcessor
    {
        //task that returns a comicmodel and takes in a default number of 0
        // 0 is current or whatever number you're looking for
        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {

            string url = "";

            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{ comicNumber}/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }


            //open call to web browser aka client
            //open up new request off our new api client and wait for the response

            //one client and make sure its disposed
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //if successful -> read the data 
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

                    return comic;
                }
                else
                {
                    // if not successful  
                    throw new Exception(response.ReasonPhrase);
                }
            }
            
            

        }
    }
}
