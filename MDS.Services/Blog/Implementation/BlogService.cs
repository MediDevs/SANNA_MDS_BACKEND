using MDS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MDS.DbContext.Enums;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.DbContext.Entities;
using System.Numerics;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Blog.Implementation
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _uow;

        public BlogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetBlogs()
        {
            try
            {
                List<DbContext.Entities.Blog> blogs = new List<DbContext.Entities.Blog>();

                blogs = await _uow.ExecuteStoredProcAll<DbContext.Entities.Blog>("SPRMDS_LIST_BLOGS");

                List<BlogDto> listBlog = new List<BlogDto>();

                listBlog = blogs.Select(s => new BlogDto { Id = s.Id, Url = s.Url }).ToList();

                if (!blogs.Any())
                    return ServiceResponse.ReturnResultWith204();
                
                return ServiceResponse.ReturnResultWith200(listBlog);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> GetBlog(long blogId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@id", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = blogId },
                };

                List<DbContext.Entities.Blog> blogs = new List<DbContext.Entities.Blog>();

                blogs = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Blog>("SPRMDS_LIST_BLOG_BY_PARAM", parameters);

                List<BlogDto> listBlog = new List<BlogDto>();

                listBlog = blogs.Select(s => new BlogDto { Id = s.Id, Url = s.Url }).ToList();

                if (!listBlog.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listBlog);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> AddBlog(BlogDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@url", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.Url },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> UpdateBlog(BlogDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.Id },
                    new SqlParameter("@url", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.Url },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> DeleteBlog(BlogDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.Id },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
    }
}
