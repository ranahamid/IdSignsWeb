using System.Collections.Generic;

namespace Web.ViewModels
{
    /// <summary>
    /// View model for Paged List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedListViewModel<T> where T : class
    {
        /// <summary>
        /// PagedListViewModel
        /// </summary>
        public PagedListViewModel()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Total available items
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Total Pages
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Items of the page
        /// </summary>
        public List<T> Items { get; set; }
    }
}