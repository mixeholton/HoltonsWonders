

using MixeWonders.Model.Commands;
using MixeWonders.Model.Queries;

namespace MixeWonders.Model.Services
{
    public record BrugsUserService(UserServiceCommands Commands, UserServiceQueries Queries);
}
