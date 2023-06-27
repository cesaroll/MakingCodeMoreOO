/*
 * @author: Cesar Lopez
 * @copyright 2023 - All rights reserved
 */
using StateOverBoolean.Account.State;

namespace StateOverBoolean.Account;

public class Account
{
    public decimal Balance { get; private set; }

    private IAccountState State { get; set; }

    public Account(Action onUnfreeze)
    {
        this.State = new Active(onUnfreeze);
    }

    public void Deposit(decimal amount)
    {
        this.State = this.State.Deposit(() => this.Balance += amount);
    }

    public void Withdraw(decimal amount)
    {
        this.State = this.State.Withdraw(() => this.Balance -= amount);
    }

    public void HolderVerified()
    {
        this.State = this.State.HolderVerified();
    }

    public void Close()
    {
        this.State = this.State.Close();
    }

    public void Freeze()
    {
        this.State = this.State.Freeze();
    }
}