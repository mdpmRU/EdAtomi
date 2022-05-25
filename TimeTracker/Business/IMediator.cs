using Business.BusinessObjects;

namespace Solution;

public interface IMediator
{
    void RaiseSubmittedTimeChanged(UserData userData);
    Guid SubscribeToSubmittedTimeChanged(Action<UserData> action);
    void UnsubscribeFromSubmittedTimeChanged(Guid subscriptionId);
}