/*
 * @author: Cesar Lopez
 * @copyright 2023 - All rights reserved
 */
namespace StateOverBoolean.Account.State;

public class Closed : IAccountState
{
    public IAccountState Deposit(Action addToBalance) => this;

    public IAccountState Freeze() => this;

    public IAccountState HolderVerified() => this;

    public IAccountState Withdraw(Action substractFromBalance) => this;

    public IAccountState Close() => this;
}
