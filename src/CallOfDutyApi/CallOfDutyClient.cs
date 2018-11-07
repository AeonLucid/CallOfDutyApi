using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CallOfDutyApi.Data;
using CallOfDutyApi.Exceptions;
using CallOfDutyApi.Response;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace CallOfDutyApi
{
    public class CallOfDutyClient : IDisposable
    {
        private static readonly int RateLimitAmount = 1;

        private static readonly TimeSpan RateLimitDuration = TimeSpan.FromSeconds(2);

        private readonly FlurlClient _client;

        private readonly Semaphore _queue;

        private int _rateLimitRemaining;

        private DateTimeOffset _rateLimitResetRemaining;

        public CallOfDutyClient(string apiKey)
        {
            _client = new FlurlClient
            {
                BaseUrl = "https://cod-api.tracker.gg/v1",
                Settings = new ClientFlurlHttpSettings
                {
                    AllowedHttpStatusRange = "404"
                }
            };
            _client.WithHeader("TRN-Api-Key", apiKey);

            _queue = new Semaphore(1, 1);
            _rateLimitRemaining = RateLimitAmount;
            _rateLimitResetRemaining = DateTimeOffset.UtcNow + RateLimitDuration;
        }

        public async Task<Profile> FindPlayerAsync(Game game, Platform platform, string name)
        {
            try
            {
                _queue.WaitOne();

                if (_rateLimitRemaining == 0)
                {
                    var startTime = DateTimeOffset.UtcNow;
                    var difference = _rateLimitResetRemaining - startTime;

                    if (difference > TimeSpan.Zero)
                    {
                        await Task.Delay(difference);
                    }
                    
                    _rateLimitRemaining = RateLimitAmount;
                    _rateLimitResetRemaining = DateTimeOffset.UtcNow + RateLimitDuration;
                }
                
                var url = Url.Combine("standard", game.ToString().ToLower(), "profile", ((int)platform).ToString(), Url.Encode(name));
                var response = await url.WithClient(_client).GetJsonAsync<ProfileData>();

                if (response.Errors.Count != 0)
                {
                    var error = string.Join(" - ", response.Errors.Select(x => x.Message));
                    throw new CallOfDutyLookupException($"Failed to lookup user, error message: '{error}'.");
                }

                if (response.Data == null)
                {
                    throw new CallOfDutyLookupException("Failed to lookup user, there was no response data.");
                }

                return response.Data;
            }
            finally
            {
                _rateLimitRemaining--;
                _queue.Release();
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}