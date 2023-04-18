using AutoMapper;
using MyNoteBook.Share.Dtos;
using NoteBookWebApi.Context;
using NoteBookWebApi.Context.UnitOfWork;
using NoteBookWebApi.Context;
using MyNoteBook.Share.Extensions;

namespace NoteBookWebApi.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public LoginService(IUnitOfWork work,IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> LoginAsync(string account, string Password)
        {
            try
            {
                Password = Password.GetMD5();
                var model= work.GetRepository<User>().GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(account)&&x.Password.Equals(Password));

                if (model.Result == null)
                {
                    return new ApiResponse("账号或密码错误，请重试!");
                }

                return new ApiResponse(true, model.Result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(false,"登录失败！");
            }
        }

        public async Task<ApiResponse> Register(UserDto user)
        {
            try
            {
                var model=mapper.Map<User>(user);
                var repository=work.GetRepository<User>();

                var usermodel = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account.Equals(model.Account));

                if (usermodel != null)
                   return new ApiResponse($"当前账号：{model.Account}已存在，请重新注册！");

                model.CreateDate = DateTime.Now;
                model.Password = model.Password.GetMD5();
                await repository.InsertAsync(model);

                if (await work.SaveChangesAsync()>0)
                return new ApiResponse(true, model);

                return new ApiResponse("注册失败！");

            }
            catch (Exception ex)
            {
                return new ApiResponse("注册账号失败！");
            }
        }
    }
}
