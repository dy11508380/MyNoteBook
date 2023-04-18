using AutoMapper;
using MyNoteBook.Share.Dtos;
using NoteBookWebApi.Context.UnitOfWork;
using NoteBookWebApi.Context;
using MyNoteBook.Share.Parameters;
using System.Reflection.Metadata;
using NoteBookWebApi.Context;

namespace NoteBookWebApi.Service
{
    public class MemoService : IMemoService
    {
        public readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public MemoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            work = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(MemoDto model)
        {
            try
            {
                var note = mapper.Map<Memo>(model);
                await work.GetRepository<Memo>().InsertAsync(note);

                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, note);
                }

                return new ApiResponse("添加数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }

        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var response = work.GetRepository<Memo>();
                var notebook = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));

                response.Delete(notebook);

                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, "");
                }

                return new ApiResponse("删除数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
        {
            try
            {
                var response = work.GetRepository<Memo>();
                var notebook = await response.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Equals(parameter.Search),
                pageSize: parameter.PageSize,
                pageIndex: parameter.PageIndex,
                    orderBy: source => source.OrderByDescending(t => t.CreateDate));
                return new ApiResponse(true, notebook);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var response = work.GetRepository<Memo>();
                var notebook = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));

                return new ApiResponse(true, notebook);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateAsync(MemoDto model)
        {
            try
            {
                var note = mapper.Map<Memo>(model);
                var response = work.GetRepository<Memo>();
                var notebook = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(model.Id));

                notebook.Title = note.Title;
                notebook.UpdateDate = DateTime.Now;
                notebook.Content = note.Content;

                response.Update(notebook);

                if (await work.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true, notebook);
                }

                return new ApiResponse("更新数据异常");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

    }
}
