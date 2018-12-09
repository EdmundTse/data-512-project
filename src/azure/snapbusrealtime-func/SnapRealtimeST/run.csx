using System;
using System.Net.Http;

public static readonly string REALTIME_ENDPOINT = "http://api.pugetsound.onebusaway.org/api/gtfs_realtime/trip-updates-for-agency/40.pb?key=TEST";

private static HttpClient httpClient = new HttpClient();

public static void Run(TimerInfo myTimer, out byte[] outputBlob, ILogger log)
{
    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

    try	
    {
        var task = httpClient.GetByteArrayAsync(REALTIME_ENDPOINT);
        outputBlob = task.Result;
    }  
    catch(HttpRequestException e)
    {
        log.LogError("Exception: {0} ", e.Message);
        outputBlob = new byte[0];
    }
}