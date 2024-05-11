
using Komit.CompanionApp.Model.Commands;
using Komit.CompanionApp.Model.Queries;

namespace Komit.CompanionApp.Model.Services
{
    public record BrugsUserService(UserServiceCommands Commands, UserServiceQueries Queries);
    public record LinkADService(LinkADServiceCommands Commands, LinkADServiceQueries Queries);
}
