using SubtitleSplitterManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using SubtitleSplitter.WebApi.Models;

namespace SubtitleSplitter.WebApi.Controllers
{
    public class SubtitleSplitterController : ApiController
    {
        [HttpPost]
        public IEnumerable<string> FormatAndParseTheMessage([FromBody]Subtitle input)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (input == null)
                {
                    throw new ArgumentNullException("The argument 'input' is null or missing");
                }

                StringManipulations objStringManipulations = new StringManipulations();
                string bText = objStringManipulations.Beautify(input.SubtitleText);
                List<string> lstSplitStrings = objStringManipulations.ApplyStringSplitRules(bText);

                //var response = new HttpResponseMessage(HttpStatusCode.OK);
                //response.Content = new StringContent(JsonConvert.SerializeObject(lstSplitStrings));
                //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return lstSplitStrings;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Internal error");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return new List<string> { "No data" };
            }
        }

        [HttpGet]
        public string GetName(string name)
        {
            return String.Format("Hi {0}!", name);
        }
    }
}
