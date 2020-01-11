namespace MindMatrix.EventSource
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEventSource
    {
        Task<long> Append(string aggregateId, long expectedAggregateVersion, params Event[] eventData);

    }

    public class InMemoryEventSource : IEventSource
    {
        private Dictionary<string, List<Event>> _events = new Dictionary<string, List<Event>>();

        public Task<long> Append(string aggregateId, long expectedAggregateVersion, params Event[] eventData)
        {
            if (!_events.TryGetValue(aggregateId, out var events))
            {
                events = new List<Event>();
                _events.Add(aggregateId, events);
            }

            if (_events.Count - 1 != expectedAggregateVersion)
                throw new InvalidOperationException($"Aggregate [{aggregateId}] was version {_events.Count - 1} but Append expected {expectedAggregateVersion}.");

            events.AddRange(eventData);
            return Task.FromResult<long>(events.Count - 1);
        }
    }
}