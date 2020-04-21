namespace Producer
{
    public interface IMessage
    {
        string Content { get;set;}
    }
}
// - next up:
// ---- second document consumer
// ---- third consumer to capture email and doc