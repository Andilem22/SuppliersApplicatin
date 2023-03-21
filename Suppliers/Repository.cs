using Dapper;
using Dapper.Contrib.Extensions;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Suppliers
{
    public class Repository: IRepository
    {
        public DataTable GetDataTableByStoredProcedure(string storedProcedure, List<SqlParameter> parameters)
        {
            DataTable table = new DataTable();
            using (var con = Database.DefaultConnection())
            {
                using (var cmd = new SqlCommand(storedProcedure, con))
                {
                    if (parameters != null && parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.Fill(table);
                    }
                }
            }

            return table;
        }


        public DataTable CompetentPersonByStoredProcedure(string storedProcedure, List<SqlParameter> parameters = null)
        {
            return GetDataTableByStoredProcedure(storedProcedure, parameters);
        }


        public string AddSupplier(SupplierEntity entity)
        {
            using (SqlConnection con = Database.DefaultConnection())
            {
                var results = "";
                try
                {
                    if (entity.Code == 0)
                    {
                        con.Insert(entity).ToString();
                        results = "Saved Successfuly ";
                    }
                    else
                    {
                        var d = con.Update(entity);
                        results = "Updated Successfuly";
                    }
                }
                catch (Exception ex)
                {
                    results = ex.Message;
                    throw ex;
                }
                return results;
            }
        }

        public SupplierEntity GetSupplierByCompany(string Name)
        {
            SupplierEntity Supplier = new SupplierEntity();
            using (SqlConnection con = Database.DefaultConnection())
            {
                try
                {
                    Supplier = con.Query<SupplierEntity>("SELECT * FROM  TblSupplier Where Name = @Name", new { Name = Name }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} Exception caught.", ex);
                }
            }
            return Supplier;
        }


    }
}