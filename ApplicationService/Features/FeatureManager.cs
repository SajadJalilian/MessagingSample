﻿using ApplicationService.Features.Notification;

namespace ApplicationService.Features;

internal static class FeatureManager
{
    const string EndpointTagName = "Notification";

    internal static IServiceCollection ConfigureNotificationFeature(this IServiceCollection services)
    {
        services.AddScoped<MessagingService>();

        return services;
    }

    internal static IEndpointRouteBuilder MapCongestionFeatures(this IEndpointRouteBuilder endpoint)
    {
        var groupEndpoint = endpoint.MapGroup("/notification")
            .WithTags(EndpointTagName)
            .WithDescription("Provides endpoints related to sending notification to client");

        groupEndpoint.NotificationEndpoint();

        return endpoint;
    }
}