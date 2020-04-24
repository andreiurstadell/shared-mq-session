using Producer.Messages;

namespace Producer
{
    public interface IEmailMessage : IAuditMessage
    {
        string Content { get;set;}
    }
}