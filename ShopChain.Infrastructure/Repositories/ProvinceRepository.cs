﻿using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;

namespace ShopChain.Infrastructure.Repositories
{
    /// <summary>
    /// Repository thao tác với dữ liệu tỉnh/thành
    /// </summary>
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly AppDbContext _context;

        public ProvinceRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Xóa toàn bộ dữ liệu tỉnh/thành hiện tại và thay bằng dữ liệu mới từ API
        /// </summary>
        /// <param name="provinces">Danh sách tỉnh từ API</param>
        /// <returns>Danh sách entity đã lưu</returns>
        public async Task<List<Province>> CreateNewProvince(List<Core.Models.Province> provinces)
        {
            if (provinces == null || provinces.Count == 0)
            {
                throw new ArgumentException("Danh sách tỉnh không được rỗng.", nameof(provinces));
            }

            // Xóa toàn bộ dữ liệu cũ để đồng bộ dữ liệu mới
            _context.Wards.RemoveRange(_context.Wards);
            _context.Districts.RemoveRange(_context.Districts);
            _context.Provinces.RemoveRange(_context.Provinces);

            var entityList = provinces.Select(p => new Province
            {
                Name = p.Name,
                CodeName = p.CodeName,
                DivisionType = p.DivisionType,
                PhoneCode = p.PhoneCode,
                Districts = p.Districts.Select(d => new District
                {
                    Name = d.Name,
                    CodeName = d.CodeName,
                    DivisionType = d.DivisionType,
                    ShortCodeName = d.ShortCodeName,
                    ProvinceCode = p.Code,
                    Wards = d.Wards.Select(w => new Ward
                    {
                        Name = w.Name,
                        CodeName = w.CodeName,
                        DivisionType = w.DivisionType,
                        ShortCodeName = w.ShortCodeName,
                        DistrictCode = d.Code
                    }).ToList()
                }).ToList()
            }).ToList();

            await _context.Provinces.AddRangeAsync(entityList);
            await _context.SaveChangesAsync();

            return entityList;
        }

        /// <summary>
        /// Lấy danh sách tên các tỉnh đã lưu trong hệ thống
        /// </summary>
        /// <returns></returns>
        public Task<List<string?>> GetAllProvinceNames()
        {
            var provinceNames = _context.Provinces
                .Select(p => p.Name)
                .ToListAsync();
            return provinceNames;
        }

        /// <summary>
        /// Lấy toàn bộ tỉnh cùng các quận, phường tương ứng
        /// </summary>
        public async Task<List<Province>> GetAllProvinces()
        {
            return await _context.Provinces
                .Include(p => p.Districts)
                    .ThenInclude(d => d.Wards)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy danh sách tên quận/huyện theo tên tỉnh
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<string?>> GetAllDistrictByProvinceName(string provinceName)
        {
            if (string.IsNullOrWhiteSpace(provinceName))
            {
                throw new ArgumentException("Tên tỉnh không được rỗng.", nameof(provinceName));
            }

            return await _context.Districts
                .Where(d => d.Province.Name == provinceName).Select(d => d.Name).ToListAsync();
        }

        /// <summary>
        /// Lấy danh sách tên phường/xã theo tên quận/huyện
        /// </summary>
        /// <param name="districtName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<List<string?>> GetAllWardByDistrictName(string districtName)
        {
            if(string.IsNullOrWhiteSpace(districtName))
            {
                throw new ArgumentException("Tên quận/huyện không được rỗng.", nameof(districtName));
            }

            return _context.Wards
                .Where(w => w.District.Name == districtName)
                .Select(w => w.Name)
                .ToListAsync();
        }
    }
}
