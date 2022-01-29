using System;
using System.Collections.Generic;
using System.Linq;

namespace PaginationHelper
{
  class Program
  {
    private static readonly IList<int> collection = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
    private static PagnationHelper<int> helper;
    
    static void Main(string[] args)
    {
      helper = new PagnationHelper<int>(
        new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}, 
        10);

      var s = helper.PageItemCount(2);
    }
  }

  public class PagnationHelper<T>
  {
    private readonly IList<T> _collection;
    private readonly int _itemsPerPage;
    
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
      _collection = collection;
      _itemsPerPage = itemsPerPage;
    }
    
    public int ItemCount => _collection.Count;
    
    public int PageCount => (int)Math.Round(ItemCount / (double)_itemsPerPage, MidpointRounding.ToPositiveInfinity);
    
    public int PageItemCount(int pageIndex)
    {
      if (pageIndex >= PageCount  || pageIndex < 0)
        return -1;

      return _collection
        .Skip(pageIndex * _itemsPerPage)
        .Take(_itemsPerPage)
        .Count();
    }
    
    public int PageIndex(int itemIndex)
    {
      if (itemIndex >= ItemCount || itemIndex < 0)
      {
        return -1;
      }

      return itemIndex / _itemsPerPage;
    }
  }
}