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
        [Route("email")]
        public async Task PublishEmail()
        {
            await _endpoint.Publish<IEmailMessage>(new { Content = "msg" });
        }
        [Route("doc")]
        public async Task PublishDoc()
        {
            await _endpoint.Publish<IDocMessage>(new { Text = "msg22" });
        }
    }
}