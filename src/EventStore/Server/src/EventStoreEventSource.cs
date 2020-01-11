namespace MindMatrix.EventSource
{
    using System.Linq;
    using System.Threading.Tasks;
    using EventStore.ClientAPI;

    public class EventStoreEventSource : IEventSource
    {
        private readonly IEventStoreConnection _eventStore;

        public EventStoreEventSource(IEventStoreConnection eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<long> Append(string aggregateId, long expectedAggregateVersion, params Event[] eventData)
        {
            var result = await _eventStore.AppendToStreamAsync(
                aggregateId,
                expectedAggregateVersion,
                eventData.Select(x => new EventData(x.Id, x.Type, x.IsJson, x.Data, x.Metadata)).ToArray()
            );

            return result.NextExpectedVersion;
        }
    }
}
