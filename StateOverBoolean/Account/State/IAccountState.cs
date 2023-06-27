/*
 * @author: Cesar Lopez
 * @copyright 2023 - All rights reserved
 */
namespace StateOverBoolean.Account.State;

public interface IAccountState
{
    IAccountState Deposit(Action addToBalance);
    IAccountState Withdraw(Action substractFromBalance);
    IAccountState Freeze();
    IAccountState HolderVerified();
    IAccountState Close();

}
