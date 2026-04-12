using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plants.API;

namespace TechnologApp.ViewModels
{
    public partial class ProductsViewModel : BaseListViewModel<Product>
    {
        protected override string Endpoint => "/api/Product";
    }
}