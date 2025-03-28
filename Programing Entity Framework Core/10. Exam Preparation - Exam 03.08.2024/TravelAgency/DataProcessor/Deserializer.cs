using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using static TravelAgency.Common.Validations.BookingValidation;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder resultSb = new StringBuilder();
            const string rootName = "Customers";

            CustomerDto[]? customerDtos = XmlHelper
                .Desirialize<CustomerDto[]>(xmlString, rootName);

            if (customerDtos != null)
            {
                ICollection<Customer> customersToAdd = new List<Customer>();

                foreach (var customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (customersToAdd.Any(c => c.Email == customerDto.Email
                                            || c.FullName == customerDto.FullName
                                            || c.PhoneNumber == customerDto.PhoneNumber))
                    {
                        resultSb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer customer = new Customer
                    {
                        FullName = customerDto.FullName,
                        Email = customerDto.Email,
                        PhoneNumber = customerDto.PhoneNumber
                    };
                    customersToAdd.Add(customer);
                    string result = string.Format(SuccessfullyImportedCustomer, customerDto.FullName);
                    resultSb.AppendLine(result);

                }

                context.Customers.AddRange(customersToAdd);
                context.SaveChanges();

            }


            return resultSb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder resultSb = new StringBuilder();

            BookingDto[]? bookingDtos = JsonConvert
                .DeserializeObject<BookingDto[]>(jsonString);

            if (bookingDtos != null)
            {
                ICollection<Booking> bookingsToAdd = new List<Booking>();

                foreach (var bookingDto in bookingDtos)
                {
                    if (!IsValid(bookingDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidDate = DateTime
                        .TryParseExact(bookingDto.BookingDate,
                                        bookingDateFormat,
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                                        out DateTime bookingDateParse);

                    if (!isValidDate)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer? customer = context.Customers
                        .FirstOrDefault(c => c.FullName == bookingDto.CustomerName);

                    TourPackage? tourPackage = context.TourPackages
                        .FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                    if (customer == null || tourPackage == null)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Booking booking = new Booking
                    {
                        BookingDate = bookingDateParse,
                        Customer = customer,
                        TourPackage = tourPackage
                    };

                    bookingsToAdd.Add(booking);
                    string result = string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDto.BookingDate);
                    resultSb.AppendLine(result);

                }
                  context.Bookings.AddRange(bookingsToAdd);
                 context.SaveChanges();
            }

            return resultSb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
