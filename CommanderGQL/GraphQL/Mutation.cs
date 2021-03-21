using CommanderGQL.Data;
using CommanderGQL.GraphQL.Inputs;
using CommanderGQL.GraphQL.Payloads;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading;
using System.Threading.Tasks;

namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<PlatformPayload> AddPlatform(
            PlatformInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(
                nameof(Subscription.OnPlatformAdded),
                platform,
                cancellationToken);

            return new PlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<CommandPayload> AddCommand(
            CommandInput input,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var command = new Command
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(
                nameof(Subscription.OnCommandAdded),
                command,
                cancellationToken);

            return new CommandPayload(command);
        }
    }
}
