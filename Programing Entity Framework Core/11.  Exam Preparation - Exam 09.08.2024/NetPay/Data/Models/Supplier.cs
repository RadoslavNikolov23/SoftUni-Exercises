namespace NetPay.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static NetPay.Common.ModelsValdiations.SupplierValdiations;

    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(supplierNameMaxLength)]
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();

    }
}