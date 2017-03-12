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
        //public ResultObj result = new ResultObj();
        public Result_elastic result = new Result_elastic();
        private int Result_ID = 1;
        private string searchStr = "";

        // constructor
        public SearchBoxModel()
        {
            //   
        }
        public SearchBoxModel(string input)
        {
            //int length = input.Length;
            //Result_ID = length % 6;
            searchStr = input;
        }

        // method - api rest
        //public async Task<ResultObj> getData()
        //{
        //    ResultObj data = new ResultObj();

        //    string url = "http://dangnguyenthehung.somee.com/rest/api/person/" + Result_ID;

        //    data = await getRESTAsync(url);//.ConfigureAwait(continueOnCapturedContext: false);
        //    return data;
        //}

        //public async Task<ResultObj> getRESTAsync(string url)
        //{
        //    HttpClient client = new HttpClient();
        //    ResultObj Items = new ResultObj();

        //    Uri uri = new Uri(url);

        //    try
        //    {
        //        var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            Items = JsonConvert.DeserializeObject<ResultObj>(content);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(@"ERROR {0}", ex.Message);
        //    }

        //    return Items;
        //}

        // method - api elastic
        public async Task<Result_elastic> getData()
        {
            Result_elastic data = new Result_elastic();

            string url = "http://dangnguyenthehung.somee.com/elasticTest/api/elasticDemo/?name=" + searchStr;

            data = await getRESTAsync(url);//.ConfigureAwait(continueOnCapturedContext: false);
            return data;
        }

        public async Task<Result_elastic> getRESTAsync(string url)
        {
            HttpClient client = new HttpClient();
            Result_elastic Items = new Result_elastic();

            Uri uri = new Uri(url);

            try
            {
                var response = await client.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<Result_elastic>(content);
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
