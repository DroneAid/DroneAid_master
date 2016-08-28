using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using DroneAidWP81.Helper;
using RestSharp.Deserializers;
using DroneAidWP81.Models;

namespace DroneAidWP81
{
    public class WebServices
    {
        public static async Task<EmergencyResponseModel> EmergencyService(double latitude, double longitude)
        {
            string formatedLatitude = latitude.ToString().Replace(".",","); 
            string formatedLongitude = longitude.ToString().Replace(".",","); 

            var client = new RestClient(Constants.SERVER_BASE_URL);
            var request = new RestRequest(String.Format("api/calldroneaid/{0}/{1}", formatedLatitude, formatedLongitude), Method.GET);

            IRestResponse response = await client.ExecuteTask(request);
            try
            {
                JsonDeserializer deserializer = new JsonDeserializer();
                return deserializer.Deserialize<EmergencyResponseModel>(response);
            }
            catch (Exception ex)
            {
                return new EmergencyResponseModel();
            }
        }
    }
    public static class RestClientExtensions
    {
        public static Task<IRestResponse> ExecuteTask(this IRestClient restClient, RestRequest restRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            restClient.ExecuteAsync(restRequest, (restResponse, asyncHandle) =>
            {
                if (restResponse.ResponseStatus == ResponseStatus.Error)
                    tcs.SetException(restResponse.ErrorException);
                else
                    tcs.SetResult(restResponse);
            });
            return tcs.Task;
        }
    }
}
