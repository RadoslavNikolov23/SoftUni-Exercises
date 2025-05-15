using Microsoft.EntityFrameworkCore;
using NetPay.Common;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var housolds = context
                .Households
                .Include(h => h.Expenses)
                .ThenInclude(e => e.Service)
                .Where(h => h.Expenses.Any(e => e.PaymentStatus!=PaymentStatus.Paid))
                .OrderBy(h => h.ContactPerson)
                .ToArray()
                .Select(h => new ExportHouseholdsDto
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                        .ToArray()
                        .Select(e => new ExportExpenseHouseholdDto
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("F2"),
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.Service.ServiceName
                        })
                        .ToArray()
                        .OrderBy(e => e.PaymentDate.ToString())
                        .ThenBy(e => e.Amount.ToString())
                        .ToArray()
                })
                .ToArray();

            string result = XmlHelper.Serialize(housolds, "Households");
            return result;
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var services = context
                .Services
                .Include(s => s.SuppliersServices)
                .ThenInclude(ss => ss.Supplier)
                .ToArray()
                .Select(s => new
                {
                    ServiceName = s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .Select(ss => new
                        {
                            SupplierName = ss.Supplier.SupplierName,
                        })
                        .OrderBy(ss => ss.SupplierName)
                        .ToArray()
                })
                .OrderBy(s => s.ServiceName)
                .ThenBy(s => s.Suppliers)
                .ToArray();

            string result = JsonConvert
                .SerializeObject(services, Formatting.Indented);
            return result;
        }
    }
}
