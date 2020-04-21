using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Producer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private IPublishEndpoint _endpoint;

        public PublishController(IPublishEndpoint publishEndpoint)
        {
            _endpoint = publishEndpoint;
        }
        public async Task Publish()
        {
            await _endpoint.Publish<IMessage>(new { Content = "msg" });
        }
    }
}