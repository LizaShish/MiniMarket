using MiniMarket.Models;
namespace MiniMarket.Helpers;
public class PaginationHelper
{
 public static IQueryable<T> Paginate<T>(IQueryable<T> query, int page, int pageSize)
 {
  return query.Skip((page - 1) * pageSize).Take(pageSize);
 }

 public static int GetTotalPages(int totalCount, int pageSize)
 {
  return (int)Math.Ceiling((double)totalCount / (double)pageSize);
 }
}