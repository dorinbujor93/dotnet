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
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BikeService(IBikeRepository bikeRepository, IUnitOfWork unitOfWork)
        {
            _bikeRepository = bikeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Bike>> ListAsync()
        {
            return await _bikeRepository.ListAsync();
        }

        public async Task<Bike> GetAsync(int id)
        {
            return await _bikeRepository.FindByIdAsync(id);
        }

        public async Task<BikeResponse> SaveAsync(Bike bike)
        {
            try
            {
                await _bikeRepository.AddAsync(bike);
                await _unitOfWork.CompleteAsync();

                return new BikeResponse(bike);
            }
            catch (Exception ex)
            {
                return new BikeResponse($"An error occurred when saving bike: {ex.Message}");
            }
        }

        public async Task<BikeResponse> UpdateAsync(int id, Bike bike, string eTag)
        {
            var existingBike = await _bikeRepository.FindByIdAsync(id);

            if (existingBike == null)
                return new BikeResponse("Bike not found.");

            if (Hashing.GetHashString(existingBike.RowVersion) != eTag)
            {
                return new BikeResponse("Incorrect eTag");
            }
            existingBike.FrameType = bike.FrameType;
            existingBike.FrameSize = bike.FrameSize;
            existingBike.BikeOwnerId = bike.BikeOwnerId;
            existingBike.CategoryId = bike.CategoryId;
            existingBike.Color = bike.Color;

            try
            {
                _bikeRepository.Update(existingBike);
                await _unitOfWork.CompleteAsync();

                return new BikeResponse(existingBike);
            }
            catch (Exception ex)
            {
                return new BikeResponse($"An error occurred when updating bike: {ex.Message}");
            }
        }

        public async Task<BikeResponse> DeleteAsync(int id)
        {
            var existingBike = await _bikeRepository.FindByIdAsync(id);

            if (existingBike == null)
                return new BikeResponse("Category not found.");

            try
            {
                _bikeRepository.Remove(existingBike);
                await _unitOfWork.CompleteAsync();

                return new BikeResponse(existingBike);
            }
            catch (Exception ex)
            {
                return new BikeResponse($"An error occurred when deleting bike: {ex.Message}");
            }
        }
    }
}