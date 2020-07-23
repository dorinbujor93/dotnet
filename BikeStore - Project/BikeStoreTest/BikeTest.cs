using System;
using AutoMapper;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using BikeStore___Project.Resources;
using BikeStore___Project.Services;
using Xunit;
using FakeItEasy;

namespace BikeStoreTest
{
    public class BikeTest
    {
        private Bike _bike;

        public BikeTest()
        {
            _bike = new Bike()
            {
                Id = 3,
                Color = "Red",
                FrameType = EFrameType.Aluminum,
                FrameSize = EFrameSize.Medium,
                CategoryId = 1,
                BikeOwnerId = 3,
            };
        }

        [Fact]
        public void NotNullAfterSave()
        {
            //Arrange
            var unitOfWork = A.Fake<IUnitOfWork>();
            var bikeRepo = A.Fake<IBikeRepository>();
            var bikeMngService = new BikeService(bikeRepo, unitOfWork);

            //Act
            A.CallTo(() => bikeRepo.AddAsync(_bike));

            //Assert
            Assert.NotNull(bikeMngService.SaveAsync(_bike));
        }

        [Fact]
        public void DeleteReturnsTrue()
        {
            //Arrange
            var unitOfWork = A.Fake<IUnitOfWork>();
            var bikeRepo = A.Fake<IBikeRepository>();
            var bikeMngService = new BikeService(bikeRepo, unitOfWork);

            //Act
            A.CallTo(() => bikeRepo.FindByIdAsync(3)).Returns(_bike);

            //Assert
            Assert.True(bikeMngService.DeleteAsync(3).Result.Success);
        }
    }
}