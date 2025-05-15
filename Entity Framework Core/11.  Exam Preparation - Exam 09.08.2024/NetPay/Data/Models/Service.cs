﻿namespace NetPay.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static NetPay.Common.ModelsValdiations.ServiceValidations;
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(serviceNameMaxLength)]
        public string ServiceName { get; set; } = null!;

        public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();

        public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();

    }
}