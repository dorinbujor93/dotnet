using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using BikeStore___Project.Domain.Services;
using BikeStore___Project.Domain.Services.Communication;

namespace BikeStore___Project.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ShopService(IShopRepository shopRepository, IUnitOfWork unitOfWork)
        {
            _shopRepository = shopRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Shop>> ListAsync()
        {
            return await _shopRepository.ListAsync();
        }
             public async Task<ShopResponse> SaveAsync(Shop shop)
        {
            try
            {
                await _shopRepository.AddAsync(shop);
                await _unitOfWork.CompleteAsync();

                return new ShopResponse(shop);
            }
            catch (Exception e)
            {
                return new ShopResponse($"An error occurred when saving the shop: {e.Message}");
            }
        }

        public async Task<ShopResponse> UpdateAsync(int id, Shop shop, string eTag)
        {
            var existingShop = await _shopRepository.FindByIdAsync(id);

            if (existingShop == null)
            {
                return new ShopResponse("Shop Not Found!");
            }

            if (Hashing.GetHashString(existingShop.RowVersion) != eTag)
            {
                return new ShopResponse("Incorrect eTag!");
            }
            existingShop.Address = shop.Address;
            existingShop.Name = shop.Name;

            try
            {
                _shopRepository.Update(existingShop);
                await _unitOfWork.CompleteAsync();

                return new ShopResponse(shop);
            }
            catch (Exception e)
            {
                return new ShopResponse($"An error occurred when saving the shop: {e.Message}");
            }
        }

        public async Task<ShopResponse> DeleteAsync(int id)
        {
            var existingShop = await _shopRepository.FindByIdAsync(id);

            if (existingShop == null)
            {
                return new ShopResponse("Shop Not Found!");
            }

            try
            {
                _shopRepository.Remove(existingShop);
                await _unitOfWork.CompleteAsync();

                return new ShopResponse(existingShop);
            }
            catch (Exception e)
            {
                return new ShopResponse($"An error occurred when deleting the shop: {e.Message}");
            }
        }

        public async Task<Shop> GetAsync(int id)
        {
            return await _shopRepository.FindByIdAsync(id);
        }
    }
}