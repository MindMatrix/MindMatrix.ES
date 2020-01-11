namespace MindMatrix.EventSource
{
    using System;

    public class Event
    {
        public readonly Guid Id;
        public readonly string Type;
        public readonly bool IsJson;
        public readonly byte[] Data;
        public readonly byte[] Metadata;

        public Event(Guid id, string type, bool isJson, byte[] data, byte[] metadata)
        {
            Id = id;
            Type = type;
            IsJson = isJson;
            Data = data;
            Metadata = metadata;
        }
    }
}