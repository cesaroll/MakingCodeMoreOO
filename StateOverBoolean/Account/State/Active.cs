/*
 * @author: Cesar Lopez
 * @copyright 2023 - All rights reserved
 */
using System.Reflection.Metadata;

namespace StateOverBoolean.Account.State;

public class Active : IAccountState
{
    private Action OnUnfreeze { get; }

    public Active(Action onUnfreeze)
    {
        this.OnUnfreeze = onUnfreeze;
    }

    public IAccountState Close() => new Closed();

    public IAccountState Deposit(Action addToBalance)
    {
        addToBalance();
        return this;
    }

    public IAccountState Freeze() => new Frozen(this.OnUnfreeze);

    public IAccountState HolderVerified() => this;

    public IAccountState Withdraw(Action substractFromBalance)
    {
        substractFromBalance();
        return this;
    }
}
