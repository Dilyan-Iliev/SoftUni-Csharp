﻿namespace RealEstates.Services
{
    using AutoMapper;
    using RealEstates.Services.Profiler;
    using System;

    public abstract class BaseService
    {
        public BaseService()
        {
            InitializeAutoMapper();
        }

        protected IMapper Mapper { get; private set; }

        private void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RealEstateProfiler>();
            });

            this.Mapper = config.CreateMapper();
        }
    }
}
