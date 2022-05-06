using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Contracts;
using Store.Contracts.Dtos;

namespace Store.Business.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(ProductDto newsDto);

        Task<PagedResponseModel<ProductDto>> PagedQueryAsync(PageFilter filter);

        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto> GetByIdAsync(Guid id);
        Task UpdateAsync(ProductDto newsDto);

        Task DeleteAsync(ProductDto newsDto);
    }
}
