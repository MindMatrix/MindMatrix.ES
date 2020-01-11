namespace MindMatrix.EventSource
{
    using System.Linq;
    public partial class AppendRequest
    {
        public static AppendRequest Create(string aggregateId, long expectedVersion, Event[] data)
        {
            var request = new AppendRequest()
            {
                Id = aggregateId,
                ExpectedAggregateVersion = expectedVersion
            };

            request.Events.AddRange(data.Cast<AppendEvent>());
            return request;
        }
    }
}