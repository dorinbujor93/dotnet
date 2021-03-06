﻿namespace Hotels.Api.Services
{
    using System;
    using Microsoft.Extensions.Logging;

    public interface ISimpleLogger
    {
        void LogInfo(string message);
    }

    public class SimpleLogger : ISimpleLogger
    {
        private readonly Guid id;
        private readonly ILogger<SimpleLogger> logger;

        public SimpleLogger(ILogger<SimpleLogger> logger)
        {
            this.id = Guid.NewGuid();
            
            this.logger = logger;
        }

        public void LogInfo(string message)
        {
            this.logger.LogInformation($"{this.id} : {message}");
        }
    }
}
