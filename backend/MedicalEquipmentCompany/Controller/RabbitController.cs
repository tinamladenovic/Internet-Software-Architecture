using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MedicalEquipmentCompany.Controllers
{
    [ApiController]
    [Route("api/rabbitmq")]
    public class RabbitMQController : ControllerBase
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly IMessageService _messageService;

        public RabbitMQController(ConnectionFactory connectionFactory, IHubContext<MessageHub> hubContext, IMessageService messageService)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        [HttpGet]
        public IActionResult ConsumeMessages()
        {
            // Return an immediate response
            return new ContentResult
            {
                Content = "Listening for messages...",
                ContentType = "text/plain",
                StatusCode = 200
            };
        }
    }
}