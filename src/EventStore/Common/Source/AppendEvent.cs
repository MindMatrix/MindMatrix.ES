namespace MindMatrix.EventSource
{
    public partial class AppendEvent
    {
        public static implicit operator Event(AppendEvent it) => new Event(it.Id, it.Type, it.IsJson, it.Data.ToByteArray(), it.Metadata.ToByteArray());
    }
}