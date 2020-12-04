﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pazar.Ads.Data;
using Pazar.Ads.Data.Models;
using Pazar.Ads.Models;
using Pazar.Core.Exceptions;
using Pazar.Core.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Ads.Services.Ads
{
    public class AdService : IAdService
    {
        private readonly PazarDbContext db;
        private readonly IMapper mapper;
        private readonly ILoggedUserService user;

        public AdService(PazarDbContext db, IMapper mapper, ILoggedUserService user)
        {
            this.db = db;
            this.mapper = mapper;
            this.user = user;
        }

        public async Task<IEnumerable<AdVm>> GetAll()
            => await this.db.Ads
                            .OrderByDescending(ad => ad.CreatedOn)
                            .ProjectTo<AdVm>(this.mapper.ConfigurationProvider)
                            .ToListAsync();

        public async Task<Ad> FindById(int id)
            => await this.db.Ads.FirstOrDefaultAsync(ad => ad.Id == id);

        public async Task<AdVm> GetDetails(int id)
            => await this.db.Ads
                             .Where(ad => ad.Id == id)
                             .ProjectTo<AdVm>(this.mapper.ConfigurationProvider)
                             .FirstOrDefaultAsync();

        public async Task<IEnumerable<MyAdsVm>> MyAds(string userId)
            => await this.db.Ads
                        .Where(ad => ad.UserId == userId)
                        .ProjectTo<MyAdsVm>(this.mapper.ConfigurationProvider)
                        .ToListAsync();

        public async Task<IEnumerable<AdVm>> GetAdsPerCategory(int id)
                => await this.db.Categories
                            .Where(c => c.Id == id)
                            .Select(c => c.Ads
                                            .Where(ad => ad.IsActive)
                                            .OrderBy(ad => ad.Title))
                            .ProjectTo<AdVm>(this.mapper.ConfigurationProvider)
                            .ToListAsync();

        public async Task<int> Total(AdsQuery query)
            => await this.db.Ads.CountAsync();

        public async Task<bool> Create(AdCreateIm input)
        {
            var category = await this.db.Categories.FirstOrDefaultAsync(c => c.Id == input.CategoryId);

            if (category == null)
            {
                throw new InvalidOperationException($"Category with id {input.CategoryId} doesn't exits");
            }

            var ad = new Ad
            {
                Title = input.Title,
                Price = input.Price,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                IsActive = input.IsActive,
                CategoryId = input.CategoryId,
                UserId = user.Id
            };

            this.db.Ads.Add(ad);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Edit(AdEditIm input)
        {
            var ad = await this.db.Ads.FindAsync(input.Id);

            if (ad == null)
            {
                throw new NotFoundException($"{ad} doesn't exists");
            }

            if (ad.UserId != this.user.Id)
            {
                throw new InvalidOperationException("You are not the owner of this ad");
            }

            var category = await this.db.Categories.FirstOrDefaultAsync(c => c.Id == input.CategoryId);

            if (category == null)
            {
                throw new InvalidOperationException($"This {input.CategoryId} doesn't exits");
            }

            this.mapper.Map(input, ad);

            this.db.Entry(ad).State = EntityState.Modified;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var ad = await this.db.Ads.FindAsync(id);

            if (ad == null)
            {
                return false;
            }

            this.db.Remove(ad);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeAvailability(int id)
        {
            var ad = await this.db.Ads.FindAsync(id);

            if (ad == null)
            {
                throw new NotFoundException($"{ad} doesn't exists");
            }

            if (ad.UserId != this.user.Id)
            {
                throw new InvalidOperationException("You are not the owner of this ad");
            }

            ad.IsActive = !ad.IsActive;

            this.db.Entry(ad).State = EntityState.Modified;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
