namespace InterfaceSegregationIdentityBefore
{
    using System.Collections.Generic;

    using InterfaceSegregationIdentityBefore.Contracts;

    public class AccountManager : IAccountManager
    {

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }
    }
}
