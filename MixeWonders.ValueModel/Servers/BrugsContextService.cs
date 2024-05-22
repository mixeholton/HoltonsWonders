

using MixeWonders.Values.Commands;
using MixeWonders.Values.Queries;

namespace MixeWonders.Values.Services
{
    public record BrugsUserService(UserServiceCommands Commands, UserServiceQueries Queries);
}
