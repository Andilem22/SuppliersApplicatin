

using Dapper.Contrib.Extensions;
using System.ComponentModel;

namespace Suppliers.Models
{
    [Table("TblSupplier")]

    public class SupplierEntity
    {
        [Key]
        public int Code { get; set; }
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [DisplayName("Telephone Number")]
        public string TelephoneNO { get; set; }
    }
}