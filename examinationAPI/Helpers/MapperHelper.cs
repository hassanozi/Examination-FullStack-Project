using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace examinationAPI.Helpers
{
    // public static class MapperHelper 
    // {
    //     public static IMapper Mapper { get; set; }

    //     public static IEnumerable<TResult> Map<TResult>(this IQueryable source)
    //     {
    //         return source.ProjectTo<TResult>(Mapper.ConfigurationProvider);
    //     }

    //     // for create and read
    //     public static TResult MapOne<TResult>(this object source)
    //     {
    //         return Mapper.Map<TResult>(source);
    //     }

    //     // for update.Many-to-many,Self-reference,Child collections,  MODIFIES AN EXISTING OBJECT
    //     public static void MapTo<TSource, TDestination>(this TSource source, TDestination destination)
    //     {
    //         Mapper.Map(source, destination);
    //     }

    // }
    public static class MapperHelper
{
    public static IMapper Mapper { get; set; }

    public static IEnumerable<TResult> Map<TResult>(this IQueryable source)
        => source.ProjectTo<TResult>(Mapper.ConfigurationProvider);

    public static TResult MapOne<TResult>(this object source)
        => Mapper.Map<TResult>(source);

    public static void MapTo<TSource, TDest>(this TSource source, TDest dest)
        => Mapper.Map(source, dest);
}

}