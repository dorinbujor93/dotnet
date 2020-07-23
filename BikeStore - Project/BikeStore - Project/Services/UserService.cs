using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using BikeStore___Project.Domain.Services;
using BikeStore___Project.Domain.Services.Communication;

namespace BikeStore___Project.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }


        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user, string eTag)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
            {
                return new UserResponse("User not found!");
            }

            if (Hashing.GetHashString(existingUser.RowVersion) != eTag)
            {
                return new UserResponse("Invalid If-match!");
            }   

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Gender = user.Gender;
            existingUser.Role = user.Role;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
            {
                return new UserResponse("User not found!");
            }

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when deleting the user: {e.Message}");
            }
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }
    }
}
