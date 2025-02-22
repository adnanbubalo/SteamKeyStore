using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamKeyStore.Model.Utlity
{
    public class Metadata
    {
        public int? Count { get; set; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public bool HasPrevious => CurrentPage > 0;
        public bool HasNext => CurrentPage < TotalPages - 1;
        public Metadata(int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            Count = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
