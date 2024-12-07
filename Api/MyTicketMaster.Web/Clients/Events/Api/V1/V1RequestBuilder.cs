// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using MyTicketMaster.Web.Clients.Events.Api.V1.Events;
using MyTicketMaster.Web.Clients.Events.Api.V1.Venues;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace MyTicketMaster.Web.Clients.Events.Api.V1
{
    /// <summary>
    /// Builds and executes requests for operations under \api\v1
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class V1RequestBuilder : BaseRequestBuilder
    {
        /// <summary>The events property</summary>
        public global::MyTicketMaster.Web.Clients.Events.Api.V1.Events.EventsRequestBuilder Events
        {
            get => new global::MyTicketMaster.Web.Clients.Events.Api.V1.Events.EventsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The venues property</summary>
        public global::MyTicketMaster.Web.Clients.Events.Api.V1.Venues.VenuesRequestBuilder Venues
        {
            get => new global::MyTicketMaster.Web.Clients.Events.Api.V1.Venues.VenuesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MyTicketMaster.Web.Clients.Events.Api.V1.V1RequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V1RequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api/v1", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::MyTicketMaster.Web.Clients.Events.Api.V1.V1RequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V1RequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/api/v1", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
