using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MDS.Dto.List
{
    public class TablaPaginacionList 
    {
        public TablaPaginacionList()
        {
        }

        public int Skip { get;  set; }
        public int TotalPages { get;  set; }
        public int PageSize { get;  set; }
        public int TotalCount { get;  set; }

        public List<object> Result { get;  set; }

        //public TablaPaginacionList(List<object> items, int count, int skip, int pageSize)
        //{
        //    TotalCount = count;
        //    PageSize = pageSize;
        //    Skip = skip;
        //    TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        //    AddRange(items);
        //}

        //public async Task<TablaPaginacionList> Create(List<Object> source,int count, int skip, int pageSize)
        //{
         
        //    var dtoPageList = new TablaPaginacionList(source, count, skip, pageSize);
        //    return dtoPageList;
        //}
        //public async Task<int> GetCount(IQueryable<AuditoriaLoginDto> source)
        //{
        //    return await source.AsNoTracking().CountAsync();
        //}

        //public async Task<List<AuditoriaLoginDto>> GetDtos(IQueryable<AuditoriaLoginDto> source, int skip, int pageSize)
        //{
        //    var entities = await source
        //        .Skip(skip)
        //        .Take(pageSize)
        //        .AsNoTracking()
        //        .Select(c => new AuditoriaLoginDto
        //        {
        //            codigoAuditoria = c.codigoAuditoria,
        //            fecha = c.fecha,
        //            origen = c.origen,
        //            ip = c.ip,
        //            estado = c.estado,
        //            usuario = c.usuario,
        //            latitud = c.latitud,
        //            longitud = c.longitud
        //        })
        //        .ToListAsync();
        //    return entities;
        //}
    }
}
