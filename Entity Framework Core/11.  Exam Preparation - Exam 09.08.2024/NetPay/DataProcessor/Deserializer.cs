using NetPay.Common;
using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using static NetPay.Common.ModelsValdiations.ExpenseValidations;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            StringBuilder resultSb = new StringBuilder();

            const string rootName = "Households";

            ImportHouseholdDto[]? importedHouseholdDtos = XmlHelper
                .Desirialize <ImportHouseholdDto[]>(xmlString, rootName);

            if (importedHouseholdDtos != null)
            {
                ICollection<Household> householdsToAdd = new List<Household>();

                foreach(var householdDto in importedHouseholdDtos)
                {
                    if (!IsValid(householdDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (householdsToAdd.Any(h => h.PhoneNumber == householdDto.PhoneNumber
                                                || h.ContactPerson == householdDto.ContactPerson
                                                || h.Email == householdDto.Email))
                    {
                        resultSb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household household = new Household
                    {
                        ContactPerson = householdDto.ContactPerson,
                        Email = householdDto.Email,
                        PhoneNumber = householdDto.PhoneNumber
                    };
                    householdsToAdd.Add(household);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedHousehold, household.ContactPerson));
                }

                context.Households.AddRange(householdsToAdd);
                context.SaveChanges();
            }

            return resultSb.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder resultSb = new StringBuilder();

            ImportExpensesDto[]? importedExpensesDtos = JsonConvert
                .DeserializeObject<ImportExpensesDto[]>(jsonString);

            if (importedExpensesDtos != null)
            {
                ICollection<Expense> expensesToAdd = new List<Expense>();

                foreach (var expenseDto in importedExpensesDtos)
                {
                    if (!IsValid(expenseDto))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }


                    if(context.Expenses.Any(e=>e.Household.Id == expenseDto.HouseholdId
                                            || e.Service.Id == expenseDto.ServiceId))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!context.Households.Any(h => h.Id == expenseDto.HouseholdId)
                        || !context.Services.Any(s => s.Id == expenseDto.ServiceId))
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime.TryParseExact
                                     (expenseDto.DueDate, 
                                     expenseDueDateInputFormat,CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out DateTime dueDateParse);
                    bool isPaymentStatusValid = Enum.TryParse<PaymentStatus>
                        (expenseDto.PaymentStatus, out PaymentStatus paymentStatusParse);

                    if(!isDueDateValid || !isPaymentStatusValid)
                    {
                        resultSb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense expense = new Expense
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount,
                        DueDate = dueDateParse,
                        PaymentStatus = paymentStatusParse,
                        HouseholdId = expenseDto.HouseholdId,
                        ServiceId = expenseDto.ServiceId
                    };
                    expensesToAdd.Add(expense);
                    resultSb.AppendLine(string.Format(SuccessfullyImportedExpense, expense.ExpenseName, expense.Amount.ToString("F2")));
                }
                context.Expenses.AddRange(expensesToAdd);
                context.SaveChanges();
            }

                return resultSb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
