﻿using Microsoft.EntityFrameworkCore;
using SoundSystemShop.DAL;
using SoundSystemShop.Models;
using SoundSystemShop.Services.Interfaces;
using System.Linq;

namespace SoundSystemShop.Services
{
    public class SliderRepository : GenericRepository<Slider>, ISliderRepository
    {
        public SliderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public bool Any(Func<Slider, bool> func)
        {
            return _dbSet.Any(func);
        }
    }
}
