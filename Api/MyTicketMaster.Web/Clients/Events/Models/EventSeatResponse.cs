// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace MyTicketMaster.Web.Clients.Events.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class EventSeatResponse : IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The seatAvailabilityStatus property</summary>
        public int? SeatAvailabilityStatus { get; set; }
        /// <summary>The seatId property</summary>
        public Guid? SeatId { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::MyTicketMaster.Web.Clients.Events.Models.EventSeatResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::MyTicketMaster.Web.Clients.Events.Models.EventSeatResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::MyTicketMaster.Web.Clients.Events.Models.EventSeatResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "seatAvailabilityStatus", n => { SeatAvailabilityStatus = n.GetIntValue(); } },
                { "seatId", n => { SeatId = n.GetGuidValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("seatAvailabilityStatus", SeatAvailabilityStatus);
            writer.WriteGuidValue("seatId", SeatId);
        }
    }
}
#pragma warning restore CS0618
