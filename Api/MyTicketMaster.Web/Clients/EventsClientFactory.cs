using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using MyTicketMaster.Web.Clients.Events;

namespace MyTicketMaster.Web.Clients
{
    public class EventsClientFactory
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly HttpClient _httpClient;

        public EventsClientFactory(HttpClient httpClient)
        {
            _authenticationProvider = new AnonymousAuthenticationProvider();
            _httpClient = httpClient;
        }

        //public EventsClient GetClient()
        //{
        //    return new EventsClient(new HttpClientRequestAdapter(_authenticationProvider, httpClient: _httpClient));
        //}

        public HttpClient GetClient()
        {
            return _httpClient;
        }
    }
}
