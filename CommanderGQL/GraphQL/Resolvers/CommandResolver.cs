using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using System.Linq;

namespace CommanderGQL.GraphQL.Resolvers
{
    public class CommandResolver
    {
        public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
        {
            return context.Commands.Where(x => x.PlatformId == platform.Id);
        }
    }
}
