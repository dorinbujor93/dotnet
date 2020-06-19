namespace InterfaceSegregationIdentityBefore.Contracts
{
    using System.Collections.Generic;

    public interface IAccountManager
    {
        void ChangePassword(string oldPass, string newPass);
    }
}

