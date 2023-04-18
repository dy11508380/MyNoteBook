﻿using Microsoft.AspNetCore.Mvc;
using MyNoteBook.Share.Parameters;
using NoteBookWebApi.Context;

namespace NoteBookWebApi.Service
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetAllAsync(QueryParameter parameter);

        Task<ApiResponse> GetSingleAsync(int id);

        Task<ApiResponse> AddAsync(T model);


        Task<ApiResponse> UpdateAsync(T model);

        Task<ApiResponse> DeleteAsync(int id);
    }
}
