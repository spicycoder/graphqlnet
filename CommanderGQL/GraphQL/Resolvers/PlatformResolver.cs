using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using System.Linq;

namespace CommanderGQL.GraphQL.Resolvers
{
    public class PlatformResolver
    {
        public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
        {
            return context.Platforms.FirstOrDefault(x => x.Id == command.PlatformId);
        }
    }
}
