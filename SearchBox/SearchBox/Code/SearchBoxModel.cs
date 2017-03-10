using Newtonsoft.Json;
using ObjCRuntime;
using SearchBox.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace SearchBox.Code
{
    public class SearchBoxModel
    {
        public ResultObj result = new ResultObj();
        private int Result_ID = 1;

        // constructor
        public SearchBoxModel()
        {
            //   
        }
        public SearchBoxModel(string input)
        {
            int length = input.Length;
            Result_ID = length % 6;
        }

        // method
        public async Task<ResultObj> getData()
        {
            ResultObj data = new ResultObj();

            string url = "http://192.168.1.48:8801/api/person/" + Result_ID;

            data = await getRESTAsync(url);//.ConfigureAwait(continueOnCapturedContext: false);
            return data;
        }

        public async Task<ResultObj> getRESTAsync(string url)
        {
            HttpClient client = new HttpClient();
            ResultObj Items = new ResultObj();
            
            Uri uri = new Uri(url);

            try
            {
                var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ResultObj>(content);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
