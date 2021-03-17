using CommanderGQL.Data;
using CommanderGQL.GraphQL.Resolvers;
using CommanderGQL.Models;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Types
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor
                .Description("Represents any software or service, that has a command line interface");

            descriptor
                .Field(x => x.LicenseKey)
                .Ignore();

            descriptor
                .Field(x => x.Commands)
                .ResolveWith<CommandResolver>(x => x.GetCommands(default, default))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available commands for this platform");
        }
    }
}
