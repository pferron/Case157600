using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Requests;
using WOW.WoodmenIllustrationService.SharedModels.MobileRaterModels.Responses;

namespace ProductPremiumCollector.Code
{
    class MobileRaterClient : IDisposable
    {
        private RestClient _client;

        private string _baseUrl;
        private string _endpoint;
        private TimeSpan _timeout = new TimeSpan(0,0,50);

        private int _requestCount = 0;
        private int _requestPurgeThreshold = 100;

        public MobileRaterClient(string baseUrl, string endpoint, TimeSpan timeout)
        {
            if(String.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Service Base URL cannot be null or empty.");
            }

            if (String.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("Service Endpoint cannot be null or empty.");
            }

            if (timeout < _timeout)
            {
                throw new ArgumentException($"Request timeout cannot be less than {_timeout.TotalSeconds} seconds.");
            }

            _baseUrl = baseUrl;
            _endpoint = endpoint;
            _timeout = timeout;

            _client = new RestClient(new RestClientOptions { BaseUrl = new Uri(_baseUrl), Timeout = new TimeSpan((int)_timeout.TotalMilliseconds) });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client = null;
            }
        }

        public List<RateResponse> SendRequest(LifeRateInput model, int headerCode, DateTime? rateDeterminationDate = null)
        {
            try
            {
                var request = new RestRequest(_endpoint, Method.Post) { RequestFormat = DataFormat.Json };
                request.AddObject(model);

                if (headerCode != 0)
                {
                    request.AddParameter("headerCode", headerCode, ParameterType.QueryString);
                }

                if (rateDeterminationDate != null)
                {
                    request.AddParameter("rateDeterminationDate", rateDeterminationDate, ParameterType.QueryString);
                }

                var response = _client.Execute<List<RateResponse>>(request);

                if (++_requestCount >= _requestPurgeThreshold)
                {
                    Console.WriteLine("purge");
                    RequestPurge();

                    // Reset counter
                    _requestCount = 0;
                }

                if (response.IsSuccessful)
                {
                    return response.Data;
                }
                else
                {
                    var blarg = new List<RateResponse>();
                    blarg.Add(new RateResponse() { HasError = true });

                    return blarg;
                }
            }
            catch (Exception)
            {
                var blarg = new List<RateResponse>();
                blarg.Add(new RateResponse() { HasError = true });

                return blarg;
            }
        }

        private void RequestPurge()
        {
            try
            {
                var client = new RestClient("https://lpamw-test.woodmen.net:2015/");

                var request = new RestRequest("api/Service/PurgeUploads", Method.Get);

                client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Purge Request failed. Please manually purge the WIS payloads.", ex);
            }
        }
    }
}
