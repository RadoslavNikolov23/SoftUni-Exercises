using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private IApplication application;

        public Controller() => this.application = new Application();


        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            IUser userToRegister = this.application.Users.GetByName(userName);

            if (userToRegister != null)
                return string.Format(OutputMessages.UserAlreadyRegistered, userName);

            IUser[] allUsers = this.application.Users.Models.ToArray();
            if (allUsers.Any(u => u.Email == email))
                return string.Format(OutputMessages.SameEmailIsRegistered, email);

            if (!hasDataAccess)
            {
                userToRegister = new Client(userName, email);
                this.application.Users.AddNew(userToRegister);
                return string.Format(OutputMessages.ClientRegistered, userName);
            }

            int counAdmins = 0;

            foreach (IUser user in allUsers)
            {
                if (user.GetType() == typeof(Admin)) 
                    counAdmins++;
            }

            if (counAdmins >= 2)
                return string.Format(OutputMessages.AdminCountLimited);
            
            userToRegister = new Admin(userName, email);
            this.application.Users.AddNew(userToRegister);
            return string.Format(OutputMessages.AdminRegistered, userName);
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            IProduct prodcutToAdd = null;
            if (productType == nameof(Item))
                prodcutToAdd = new Item(productName, basePrice);
            else if (productType == nameof(Service))
                prodcutToAdd = new Service(productName, basePrice);
            else
                return string.Format(OutputMessages.ProductIsNotPresented, productType);

            IProduct productToFind = this.application.Products.GetByName(productName);
            if (productToFind != null)
                return string.Format(OutputMessages.ProductNameDuplicated, productName);

            if (ChechUser(userName))
                return string.Format(OutputMessages.UserIsNotAdmin, userName);

            this.application.Products.AddNew(prodcutToAdd);
            return string.Format(OutputMessages.ProductAdded, productType, productName, $"{basePrice:f2}");
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            IProduct productToUpdate = this.application.Products.GetByName(productName);
            if (productToUpdate == null)
                return string.Format(OutputMessages.ProductDoesNotExist, productName);

            if (ChechUser(userName))
                return string.Format(OutputMessages.UserIsNotAdmin, userName);

            double oldPrice = productToUpdate.BasePrice;
            productToUpdate.UpdatePrice(newPriceValue);
            return string.Format(OutputMessages.ProductPriceUpdated, productName, $"{oldPrice:f2}", $"{newPriceValue:f2}");
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            IUser userToPurchase = this.application.Users.GetByName(userName);
            if (!this.application.Users.Exists(userName) || userToPurchase.GetType().Name == nameof(Admin))
                return string.Format(OutputMessages.UserIsNotClient, userName);

            if (!this.application.Products.Exists(productName))
                return string.Format(OutputMessages.ProductDoesNotExist, productName);

            IProduct productToPurchase = this.application.Products.GetByName(productName);
            if (productToPurchase.IsSold)
                return string.Format(OutputMessages.ProductOutOfStock, productName);

            MethodInfo methodInfo = userToPurchase.GetType().GetMethod("PurchaseProduct");

            if (methodInfo != null)
            {
                object[] parameters = new object[] { productName, blackFridayFlag };
                methodInfo.Invoke(userToPurchase, parameters);
            }
            productToPurchase.ToggleStatus();

            double priceToPurchase = 0;
            if (blackFridayFlag)
                priceToPurchase = productToPurchase.BlackFridayPrice;
            else
                priceToPurchase = productToPurchase.BasePrice;

            return string.Format(OutputMessages.ProductPurchased, userName, productName, $"{priceToPurchase:f2}");
        }

        public string RefreshSalesList(string userName)
        {
            if (ChechUser(userName))
                return string.Format(OutputMessages.UserIsNotAdmin, userName);

            int count = 0;
            foreach (var soldProduct in this.application.Products.Models)
            {
                if (soldProduct.IsSold == true)
                {
                    soldProduct.ToggleStatus();
                    count++;
                }
            }

            return string.Format(OutputMessages.SalesListRefreshed, count);
        }


        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            IRepository<IUser> allUsers = this.application.Users;

            List<IUser> adminsOnly = new List<IUser>();
            List<IUser> clientsOnly = new List<IUser>();

            foreach(IUser user in allUsers.Models)
            {
                if (user.GetType().Name == nameof(Admin))
                    adminsOnly.Add(user);
                else
                    clientsOnly.Add(user);
            }

            sb.AppendLine("Application administration:");

            foreach (var user in adminsOnly.OrderBy(a => a.UserName))
                sb.AppendLine(user.ToString());

            sb.AppendLine("Clients:");

            foreach (var user in clientsOnly.OrderBy(a => a.UserName))
            {
                sb.AppendLine(user.ToString());

                Client newUser = (Client)user;
                if (newUser.Purchases.Count > 0)
                {
                    int countPurchases = 0;
                    List<string> itemName=new List<string>();
                    foreach(var purchase in newUser.Purchases)
                    {
                        if (purchase.Value == true)
                        {
                            itemName.Add(purchase.Key);
                            countPurchases++;
                        }
                    }

                    if (countPurchases > 0)
                    {
                        sb.AppendLine($"-Black Friday Purchases: {countPurchases}");
                        foreach (var item in itemName)
                            sb.AppendLine($"--{item}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        private bool ChechUser(string userName)
        {
            IUser userToRegister = this.application.Users.GetByName(userName);
            if (!this.application.Users.Exists(userName) || userToRegister.GetType().Name == nameof(Client))
            {
                return true;
            }
            return false;
        }

    }
}
