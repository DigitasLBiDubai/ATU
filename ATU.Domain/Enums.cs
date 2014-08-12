
namespace ATU.Domain
{
    public enum RequestTypes
    {
        EditorAccount = 0,
        VenueClaim = 1,
        ContactRequest = 2
    }

    public enum RequestStatus
    {
        Rejected = -1,
        New = 0,
        Pending = 1,
        PendingViewed = 2,
        Accepted = 3
    }
}