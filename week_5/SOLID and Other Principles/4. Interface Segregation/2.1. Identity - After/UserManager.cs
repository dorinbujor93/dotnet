using SOLID_and_Other_Principles._4._Interface_Segregation._2._1._Identity___After.Contracts;

namespace InterfaceSegregationIdentityBefore
{
    using System.Collections.Generic;

    using InterfaceSegregationIdentityBefore.Contracts;

    public class UserManager : IUserManager
    {
        public IEnumerable<IUser> GetAllUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public IUser GetUserByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
