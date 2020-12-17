using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace ca3.Pages
{
    public class GetData
    {
        public HttpClient httpClient;
        private Food Data;
        private string ErrorMessage;

        string APP_ID = "cb90e89a";
        string APP_KEY = "5169595c097ab43f04267a6be8d64ade";   

        public async Task GetDataAsync()
        {
            try
            {
                string url = "https://api.edamam.com/search?q=chicken&app_id=" + APP_ID + "&app_key=" + APP_KEY;
                Data = await httpClient.GetJsonAsync<Food>(url);

                Console.WriteLine(Data.Title);
                ErrorMessage = String.Empty;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;

            }
        }

        protected async Task OnInitializedAsync()
        {
            await GetDataAsync();
        }

        public class Food
        {
            public String Title { get; set; }
        }
    }
}
