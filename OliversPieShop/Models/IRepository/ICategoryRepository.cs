using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliversPieShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}
