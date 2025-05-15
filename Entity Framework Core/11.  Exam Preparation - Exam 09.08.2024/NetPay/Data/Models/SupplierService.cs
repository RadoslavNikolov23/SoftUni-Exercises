namespace NetPay.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SupplierService
    {
        [Required]
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public Service Service { get; set; } = null!;

    }
}