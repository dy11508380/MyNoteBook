using AutoMapper;
using MyNoteBook.Share.Dtos;
using MyNoteBook.Share.Parameters;
using NoteBookWebApi.Context;
using NoteBookWebApi.Context.UnitOfWork;
using System.Reflection.Metadata;
using NoteBookWebApi.Context;
using System.Collections.ObjectModel;

namespace NoteBookWebApi.Service
{
    public class NoteBookService : INoteBookService
    {
        public readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public NoteBookService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            work = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(NoteBookDto model)
        {
            try
            {
                var note= mapper.Map<NoteBook>(model);
                await work.GetRepository<NoteBook>().InsertAsync(note);

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
                var response = work.GetRepository<NoteBook>();
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
                var response = work.GetRepository<NoteBook>();
                var notebook = await response.GetPagedListAsync(predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search),
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

        public async Task<ApiResponse> GetAllAsync(NoteBookParameter parameter)
        {
            try
            {
                var response = work.GetRepository<NoteBook>();
                var notebook = await response.GetPagedListAsync(predicate: x => ((string.IsNullOrWhiteSpace(parameter.Search) ? true : x.Title.Contains(parameter.Search))&&
                (parameter.Status==null?true: parameter.Status != null&&x.Status.Equals(parameter.Status))),
                pageSize: parameter.PageSize,
                pageIndex: parameter.PageIndex,
                    orderBy: source => source.OrderByDescending(t => t.CreateDate));;

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
                var response = work.GetRepository<NoteBook>();
                var notebook = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));

                return new ApiResponse(true, notebook);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> Summary()
        {
            try
            {
                var todo = await work.GetRepository<NoteBook>().GetAllAsync(
                    orderBy:source=>source.OrderByDescending(t=>t.CreateDate));

                var memos = await work.GetRepository<Memo>().GetAllAsync(
                    orderBy: source => source.OrderByDescending(t => t.CreateDate));

                SummaryDto summary = new SummaryDto();
                summary.Sum = todo.Count();
                summary.CompletedCount = todo.Where(t=>t.Status==1).Count();
                summary.CompletedRadio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                summary.MemoCount=memos.Count();

                summary.TodoList = new ObservableCollection<NoteBookDto>(mapper.Map<List<NoteBookDto>>(todo.Where(t => t.Status == 0)));
                summary.MemoList = new ObservableCollection<MemoDto>(mapper.Map<List<MemoDto>>(memos));

                return new ApiResponse(true, summary);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, "");
            }
        }

        public async Task<ApiResponse> UpdateAsync(NoteBookDto model)
        {
            try
            {
                var note = mapper.Map<NoteBook>(model);
                var response = work.GetRepository<NoteBook>();
                var notebook = await response.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(model.Id));

                notebook.Title = note.Title;
                notebook.UpdateDate = DateTime.Now;
                notebook.Status = note.Status;
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
