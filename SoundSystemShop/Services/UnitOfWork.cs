﻿using SoundSystemShop.DAL;
using SoundSystemShop.Services.Interfaces;

namespace SoundSystemShop.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IProductRepository ProductRepo { get ; set ; }
        public ISliderRepository SliderRepo { get; set; }
        public IBannerRepository BannerRepo { get; set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            SliderRepo = new SliderRepository(_appDbContext);
            ProductRepo = new ProductRepository(_appDbContext);
            BannerRepo = new BannerRepository(_appDbContext);
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }
    }
}
