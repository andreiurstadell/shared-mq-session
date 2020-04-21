using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer
{
    interface IMessage
    {
        string Content { get;set;}
    }
}
