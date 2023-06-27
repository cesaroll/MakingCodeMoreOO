/*
 * @author: Cesar Lopez
 * @copyright 2023 - All rights reserved
 */
namespace StateOverBoolean.Account.State;

public class NotVerified : IAccountState
{
    private Action OnUnfreeze { get; }

    public NotVerified(Action onUnfreeze)
    {
        this.OnUnfreeze = onUnfreeze;
    }

    public IAccountState Close() => new Closed();

    public IAccountState Deposit(Action addToBalance)
    {
        addToBalance();
        return this;
    }

    public IAccountState Freeze() => this;

    public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

    public IAccountState Withdraw(Action substractFromBalance) => this;
}
