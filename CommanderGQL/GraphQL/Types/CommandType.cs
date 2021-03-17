using CommanderGQL.Data;
using CommanderGQL.GraphQL.Resolvers;
using CommanderGQL.Models;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Types
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor
                .Description("An executable command on specified platform");

            descriptor
                .Field(x => x.Platform)
                .ResolveWith<PlatformResolver>(x => x.GetPlatform(default, default))
                .UseDbContext<AppDbContext>()
                .Description("Platform to which the command belongs");
        }
    }
}
