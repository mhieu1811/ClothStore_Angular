using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Business.Interfaces;
using Store.Contracts;
using Store.Contracts.Dtos;
using Store.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Business.Services
{
    public class ProductService: IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IMapper _mapper;
        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            await _baseRepository.AddAsync(Product);
        }

        public async Task<PagedResponseModel<ProductDto>> PagedQueryAsync(PageFilter filter)
        {
            var query = _baseRepository.Entities;
            query = query.Where(m => m.Published == true);
            query =query.Where(m=>string.IsNullOrWhiteSpace(filter.keySearch)||m.Name.Contains(filter.keySearch));
            var Product = await query
               .AsNoTracking()
               .PaginateAsync(filter.page, filter.limit);

            return new PagedResponseModel<ProductDto>
            {
                CurrentPage = Product.CurrentPage,
                TotalPages = Product.TotalPages,
                TotalItems = Product.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductDto>>(Product.Items)
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _baseRepository.GetAllByAsync(m=>true, "Comments,Comments.User,Pictures,Type"));
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ProductDto>(await _baseRepository.GetByIdAsync(id));

        }
        public async Task UpdateAsync(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            await _baseRepository.UpdateAsync(Product);
        }

        public async Task DeleteAsync(ProductDto ProductDto)
        {
            await _baseRepository.DeleteAsync(ProductDto.Id);
        }
    }
}
