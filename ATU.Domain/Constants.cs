
namespace ATU.Domain
{
    public static class RoleNames
    {
        public const string SuperUser = "SuperUser";
        public const string Administrator = "Administrator";
        public const string Editor = "Editor";
    }

    public static class RoleContexts
    {
        public const string AdministratorAndSuperUser = "Administrator, SuperUser";
    }

    public static class TemporalSearchScope
    {
        public const string Now = "now";
        public const string Later = "later";
        public const string Tomorrow = "tomorrow";
    }
}