using Komit.MixeWonders.Model.Entities;
using MixeWonders.Model.DbContexts;
using MixeWonders.Model.Dtos;
using MixeWonders.Model.Services;
using System.Text;


namespace MixeWonders.Model.Commands
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
