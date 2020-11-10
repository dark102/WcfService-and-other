using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDB.Data;
using WorkDB.Model;

namespace WorkDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Внимание!!! для выполнения данного ПО поменяйте сервер в MS SQL." +
                " При нажатии Enter на нём будет создана база данных и она заполнится тестовыми данными");
            using (Context context = new Context())
            {
                DefData(context);
                var viborka = context.Account.Where(x => x.CreateOn.Year > 2015);
                foreach (var ac in viborka)
                {
                    Console.WriteLine(ac.Name);
                }
                Console.WriteLine("Для закрытия нажмите любую клавишу");
                Console.ReadKey();


            }
        }
        private static void DefData(Context context)
        {
                #region Добавление Контрагентов и Контактов
                if (!context.Account.Any())
                {
                    context.Account.AddRange(
                        new Account[]
                        {
                            new Account
                            {
                                Id = Guid.NewGuid(),
                                Name = "Account1",
                                CreateOn = new DateTime(2001,12,1)
                            },
                            new Account
                            {
                                Id = Guid.NewGuid(),
                                Name = "Account2",
                                CreateOn = new DateTime(2010,12,1)
                            },
                            new Account
                            {
                                Id = Guid.NewGuid(),
                                Name = "Account3",
                                CreateOn = new DateTime(2015,12,1)
                            },
                            new Account
                            {
                                Id = Guid.NewGuid(),
                                Name = "Account4",
                                CreateOn = new DateTime(2018,12,1)
                            },
                            new Account
                            {
                                Id = Guid.NewGuid(),
                                Name = "Account5",
                                CreateOn = new DateTime(2019,12,1)
                            }
                        });
                    context.SaveChanges();
                    var tableAccount = context.Account.ToList();
                    int i = 1;
                    foreach (var row in tableAccount)
                    {
                        Contact contact = new Contact
                        {
                            Id = Guid.NewGuid(),
                            Name = $"Contact{i}",
                            AccountId = Guid.NewGuid(),
                            CreateOn = row.CreateOn
                        };
                        row.ContactId = contact.Id;
                        i++;
                        context.Contact.Add(contact);
                    }
                    context.SaveChanges();
                }
                #endregion
                #region Добавление Обращений
                if (!context.Case.Any())
                {
                    int eter = 50;
                    Case[] cases = new Case[eter];
                    var rand = new Random();
                    var tableAccount = context.Account.ToList();
                    for (int ind = 0; ind < eter; ind++)
                    {
                        var accNumb = tableAccount[rand.Next(0, tableAccount.Count)];
                        Case cas = new Case
                        {
                            Id = Guid.NewGuid(),
                            Name = "Образение" + ind,
                            AccountId = accNumb.Id,
                            ContactId = accNumb.ContactId,
                            CreateOn = new DateTime(1990, 12, 1)
                        };
                        cases[ind] = cas;
                        
                    }
                    context.Case.AddRange(cases);
                    context.SaveChanges();        
                }
                #endregion
        }
    }
}
