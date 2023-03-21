using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suppliers
{
    public interface IRepository
    {
        string AddSupplier(SupplierEntity entity);
        SupplierEntity GetSupplierByCompany(string Name);
    }
}