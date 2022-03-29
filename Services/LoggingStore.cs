using dws.models.Logging;
using MobileTime.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Services
{
    public class LoggingStore : ILoggingStore
    {
        HttpClient _httpClient;
        public LoggingStore(HttpClient client)
        {
            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "JWT " + App.AuthToken);
        }

        public async void WriteError(ErrorModel error)
        {
            try
            {
                error.CreateDate = DateTime.Now;                
                var objAsJson = JsonConvert.SerializeObject(error);
                var content = new StringContent(objAsJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = new HttpResponseMessage();
                var response = await _httpClient.PostAsync("Error/", content);
                var contents = await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                string e = ex.Message;
            }
        }

        public async Task<HttpResponseMessage> WriteErrorAsync(ErrorModel error)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            try
            {
                error.CreateDate = DateTime.Now;
                var objAsJson = JsonConvert.SerializeObject(error);
                var content = new StringContent(objAsJson, Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync("Error/", content);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return response;
        }

        public void WriteTrace(TraceModel trace)
        {
            trace.CreateDate = DateTime.Now;
            //string Level, string Logger, string Message, string StackTrace
            var objAsJson = JsonConvert.SerializeObject(trace);
            var content = new StringContent(objAsJson, Encoding.UTF8, "application/json");
            _httpClient.PostAsync("Trace", content);
        }

        public async Task<HttpResponseMessage> WriteTraceAsync(TraceModel trace)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            try
            {
                trace.CreateDate = DateTime.Now;
                var objAsJson = JsonConvert.SerializeObject(trace);
                var content = new StringContent(objAsJson, Encoding.UTF8, "application/json");
                response = await _httpClient.PostAsync("Trace/", content);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return response;
        }
    }
}
