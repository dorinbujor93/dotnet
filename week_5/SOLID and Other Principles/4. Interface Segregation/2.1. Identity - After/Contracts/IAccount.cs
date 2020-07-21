using System.Collections.Generic;

namespace SOLID_and_Other_Principles._4._Interface_Segregation._2._1.Contracts
{
    public interface IAccount
    {
        bool RequireUniqueEmail { get; set; }

        int MinRequiredPasswordLength { get; set; }

        int MaxRequiredPasswordLength { get; set; }

        void Register(string username, string password);

        void Login(string username, string password);

        void ChangePassword(string oldPass, string newPass);
    }
}
