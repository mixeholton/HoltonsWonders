namespace MixeWonders.Values.Enums
{

    public enum FormMode
    {
        None = 0,
        New = 1,
        Update = 2,
        Delete = 3
    }
    public enum AuthenticationStatus
    {
        Loading,
        Content,
        Error,
        Unauthorized
    }
    public enum TreeNodeType
    {
        Top = 0,
        Bill = 1,
        User = 2,
    }
    public enum BalanceCurrencyType
    {
        None = 0,
        Credit = 1,
        Debit = 2,
    }
    public enum WeekDay
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public enum PermissionType
    {
        None = -1,
        Bill = 0,
        Football = 1,
        BoardGames = 2,
        Counter = 3,
        Admin = 4,
        SuperAdmin = 5,
        Home = 6,
        BillAdvanded = 7,
        Permissions = 8,
        Users = 9,
        Scheduler = 10,
    }
    public enum DefaultFocusButton
    {
        Ok = 0,
        Cansel = 1
    }

    public enum ProgramType
    {
        SimpelBill,
        AdvancedBill,
        PremierLeagueGames,
        BoardGames
    }
}
