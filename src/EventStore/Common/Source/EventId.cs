namespace MindMatrix.EventSource
{
    using System;

    public partial class EventId
    {
        private EventId(string value)
        {
            Value = value;
        }

        public static implicit operator Guid(EventId it) => Guid.Parse(it.value_);
        public static implicit operator EventId(Guid it) => new EventId(it.ToString());
    }
}