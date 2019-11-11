using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.App
{
    public class DBInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
            SeedBankAccounts(context);
            SeedCreditCards(context);
            SeedPaymentMethod(context);

        }


        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            string[] firstNames = { "Stavri", "Stamat", "Gosho" };
            string[] lastNames = { "Stavrev", "Stamatov", "Goshov" };
            string[] emails = { "stavri@bps.com", "stamat@bps.com", "gosho@bps.com" };
            string[] passwords = { "stav1", "stam2", "gosh3" };

            List<User> users = new List<User>();

            for (int i = 0; i < firstNames.Length; i++)
            {
                var user = new User
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = passwords[i]
                };

                if (Validation(user) == false)
                {
                    continue;
                }

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }
        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            var creditCards = new List<CreditCard>();

            for (int i = 0; i < 8; i++)
            {
                var creditCard = new CreditCard
                {
                    Limit = new Random().Next(-25000, 25000),
                    MoneyOwed = new Random().Next(-25000, 25000),
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(-200, 200))
                };

                if (Validation(creditCard) == false)
                {
                    continue;
                }

                creditCards.Add(creditCard);
            }

            context.AddRange(creditCards);
            context.SaveChanges();
        }
        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            var bankAccounts = new List<BankAccount>();

            for (int i = 0; i < 8; i++)
            {
                var bankAccount = new BankAccount
                {
                    Balance = new Random().Next(-200, 200),
                    BankName = "Banka" + i,
                    SWIFT = "Swift" + i + 1
                };

                if (Validation(bankAccount) == false)
                {
                    continue;
                }

                bankAccounts.Add(bankAccount);
            }

            context.AddRange(bankAccounts);
            context.SaveChanges();

        }
        private static void SeedPaymentMethod(BillsPaymentSystemContext context)
        {
            var paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < 8; i++)
            {
                var paymentMethod = new PaymentMethod()
                {
                    UserId = new Random().Next(1, 4),
                    Type = (PaymentType)new Random().Next(0, 2),
                };

                //if (i % 3 == 0)
                //{
                    paymentMethod.CreditCardId = 1;
                    paymentMethod.BankAccountId = 1;
                //}
                //else if (i % 2 == 0)
                //{
                //    paymentMethod.CreditCardId = new Random().Next(1, 4);
                //}
                //else
                //{
                //    paymentMethod.BankAccountId = new Random().Next(1, 4);
                //}

                if (Validation(paymentMethod) == false)
                {
                    continue;
                }

                paymentMethods.Add(paymentMethod);

            }

            context.AddRange(paymentMethods);
            context.SaveChanges();
        }
        private static bool Validation(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool validation = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return validation;
        }

    }
}
