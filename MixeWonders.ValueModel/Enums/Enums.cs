namespace MixeWonders.Values.Enums
{

    public enum UserFormMode
    {
        None = 0,
        New = 1,
        Update = 2,
        Delete = 3
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
    public enum PermissionType
    {
        Bill = 0,
        Football = 1,
        BoardGames = 2,
        Counter = 3,
        Admin = 4,
        SuperAdmin = 5,
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
