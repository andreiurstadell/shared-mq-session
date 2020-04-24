using Producer.Messages;

namespace Producer
{
    public interface IDocMessage : IAuditMessage
    {
        string Text { get;set;}
    }
}