﻿using Core;
using MessagingService.Common.Data;

namespace MessagingService.Kernel.Inbox;

public class InboxService(ApplicationDbContext dbContext, ICustomTimeProvider timeProvider)
{
    public async Task<bool> SentNotification(SendMessageCommand command, CancellationToken cToken)
    {
        var messages = dbContext.Set<InboxMessage>();
        await messages.AddAsync(new InboxMessage
        {
            Content = command.Content,
            MessageId = command.MessageId,
            MessageType = MessageType.Full, // We can handle types later
            CreatedOn = timeProvider.UtcNow(),
        }, cToken);

        var r = await dbContext.SaveChangesAsync(cToken);
        return r > 0;
    }
}