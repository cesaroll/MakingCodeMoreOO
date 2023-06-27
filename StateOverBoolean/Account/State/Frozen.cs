/*
 * @author: Cesar Lopez
 * @copyright 2023 - All rights reserved
 */
namespace StateOverBoolean.Account.State;

public class Frozen : IAccountState
{
    private Action OnUnfreeze { get; }

    public Frozen(Action onUnfreeze)
    {
        this.OnUnfreeze = onUnfreeze;
    }

    public IAccountState Close() => new Closed();

    public IAccountState Deposit(Action addToBalance)
    {
        this.OnUnfreeze();
        addToBalance();
        return new Active(this.OnUnfreeze);
    }

    public IAccountState Freeze() => this;
    public IAccountState HolderVerified() => this;

    public IAccountState Withdraw(Action substractFromBalance)
    {
        this.OnUnfreeze();
        substractFromBalance();
        return new Active(this.OnUnfreeze);
    }
}
