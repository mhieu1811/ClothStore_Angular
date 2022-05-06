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
    public class CommentsService:ICommentService
    {
       
        private readonly IBaseRepository<Comments> _baseRepository;
        private readonly IMapper _mapper;
        public CommentsService(IBaseRepository<Comments> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(AddCommentDto commentDto)
        {
            var comments = _mapper.Map<Comments>(commentDto);
            comments.UpdatedDate = DateTime.Now;
            comments.CreatedDate = DateTime.Now;
            comments.Id= Guid.NewGuid();
            comments.Published = true;
            await _baseRepository.AddAsync(comments);
        }
        public async Task<PagedResponseModel<CommentsDto>> GetAllCommentByNewsAsync(PageFilter filter)
        {
            var query = _baseRepository.Entities;
            query=query.Where(m=>m.Published==true);
            var comments = await query
               .AsNoTracking()
               .PaginateAsync(filter.page, filter.limit);

            return new PagedResponseModel<CommentsDto>
            {
                CurrentPage = comments.CurrentPage,
                TotalPages = comments.TotalPages,
                TotalItems = comments.TotalItems,
                Items = _mapper.Map<IEnumerable<CommentsDto>>(comments.Items)
            };
        }
        public async Task UpdateAsync(EditCommentDto commentDto)
        {
            var cmt = await _baseRepository.GetByAsync(m=>m.Id==commentDto.Id&&m.UserId==commentDto.UserId,"");
            cmt.Comment = commentDto.Comment;
            await _baseRepository.UpdateAsync(cmt);
        }
        public async Task DeleteAsync(CommentsDto commentDto)
        {
            var comment = await _baseRepository.GetByIdAsync(commentDto.Id);
            if(comment != null)
            {
                comment.Published = false;
            }
            await _baseRepository.UpdateAsync(comment);
        }


    }
}
