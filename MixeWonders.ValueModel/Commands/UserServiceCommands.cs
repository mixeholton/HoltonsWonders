using MixeWonders.Values.Context;
using MixeWonders.Values.Services;


namespace MixeWonders.Values.Commands
{
    public class UserServiceCommands
    {
        protected BrugsDbContext BrugsDbContext { get; }
        protected ScopeService ScopeService { get; }
        const string BRUGER_LOGON = "-BRUGER LOGON";
        const string SQLKEY_SYSTEM = "Scan Pro Data";

        public UserServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
        }


    }
}
