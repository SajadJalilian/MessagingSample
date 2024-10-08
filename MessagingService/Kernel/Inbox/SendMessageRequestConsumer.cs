using Core;
using MassTransit;

namespace MessagingService.Kernel.Inbox;

public class SendMessageRequestConsumer(InboxService inboxService, ILogger<SendMessageRequestConsumer> logger)
    : IConsumer<SendMessageBusRequest>
{
    public async Task Consume(ConsumeContext<SendMessageBusRequest> context)
    {
        var message = context.Message;
        var messageId = context.MessageId ?? new Guid();

        await inboxService.SentNotification(new SendMessageCommand(message.Content,
                message.UserId, messageId),
            context.CancellationToken);

        logger.LogError($"id:{messageId}--content:{message.Content}");
    }
}