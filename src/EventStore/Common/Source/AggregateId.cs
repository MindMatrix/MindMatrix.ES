namespace MindMatrix.EventSource
{
    public partial class AggregateId
    {
        private AggregateId(string value)
        {
            Value = value;
        }

        public static implicit operator string(AggregateId it) => it.value_;
        public static implicit operator AggregateId(string it) => new AggregateId(it);
    }
}