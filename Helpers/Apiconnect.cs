using Newtonsoft.Json;
using System.Text;

namespace MVCDataAcessfromAPI.Helpers
{
    public class Apiconnect
    {
        private readonly IConfiguration _configuration;
        public Apiconnect(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T?> ApiCallPost<T>(string apimethod,object? dataobject=default)
        {
            string? webApi = _configuration.GetValue<string>("ApiUrl");
             string jsonparamas = string.Empty;
             Uri url = new Uri(webApi + apimethod);
            if (dataobject is not null && dataobject is not string)
            {
                jsonparamas = JsonConvert.SerializeObject(dataobject);
            }
            using HttpClient httpclient = new HttpClient();
            httpclient.Timeout = Timeout.InfiniteTimeSpan;

            //if(type.ToUpper()=="POST")
            //{
                var response = await httpclient.PostAsync(url, new StringContent(jsonparamas, Encoding.UTF8, "application/json"));

                string resresponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                   return  JsonConvert.DeserializeObject<T>(resresponse);
                }
            else
            {
                throw new InvalidOperationException(resresponse);
            }
               
            

            
            
        }
    }
}
