using Business.BusinessObjects;

namespace Solution;

public interface IMediator
{
    void RaiseSubmittedTimeChanged(UserData userData);
    Guid SubscribeToSubmittedTimeChanged(UserData userData, Action<UserData> action);
    void UnsubscribeFromSubmittedTimeChanged(Guid subscriptionId);
    void Dispose();
}