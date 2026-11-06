using EFCore04.Contexts;
using EFCore04.Entities;
using EFCore04.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EFCore04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01: Model and Database

            //Part 01: Model and Database

            #endregion

            #region Part 02: Seeding

            //Part 02: Seeding

            #endregion

            #region Part 03: Interactive Menu

            // Part 03: Interactive Menu


            //using var db = new AppDbContext();
            //db.Database.Migrate();

            //bool running = true;
            //while (running)
            //{
            //    Console.Clear();
            //    ShowMenu();
            //    var choice = Console.ReadLine()?.Trim();

            //    Console.WriteLine();
            //    try
            //    {
            //        switch (choice)
            //        {
            //            case "1": AddCustomer(); break;
            //            case "2": OpenAccount(); break;
            //            case "3": UpdateAccountStatus(); break;
            //            case "4": RemoveAccountFromCustomer(); break;
            //            case "5": ListCustomers(); break;
            //            case "0": running = false; continue;
            //            default: Error("Invalid choice. Please enter a number from the menu."); break;
            //        }
            //    }
            //    catch (DbUpdateException ex)
            //    {
            //        Error($"Database error: {ex.InnerException?.Message ?? ex.Message}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Error($"Unexpected error: {ex.Message}");
            //    }

            //    Console.WriteLine();
            //    Console.WriteLine("Press any key to return to the menu...");
            //    Console.ReadKey(true);
            //}

            //db.Database.CloseConnection();
            //Console.WriteLine("Goodbye!");

            //// ======================================================================
            //// Menu
            //// ======================================================================
            //static void ShowMenu()
            //{
            //    Console.WriteLine("=======================================");
            //    Console.WriteLine("    National Bank - Management");
            //    Console.WriteLine("=======================================");
            //    Console.WriteLine("  1) Add a new Customer");
            //    Console.WriteLine("  2) Open a new Account for a Customer");
            //    Console.WriteLine("  3) Update Account Status (Active / Closed)");
            //    Console.WriteLine("  4) Remove an Account from a Customer");
            //    Console.WriteLine("  5) List all Customers (with accounts)");
            //    Console.WriteLine("  0) Exit");
            //    Console.WriteLine("---------------------------------------");
            //    Console.Write("  Enter choice: ");
            //}

            //// ======================================================================
            //// 1) Add Customer
            //// ======================================================================
            //void AddCustomer()
            //{
            //    Console.WriteLine("--- Add New Customer ---");

            //    string fullName = ReadString("Full Name      : ", 100, v => v.Length >= 3 ? null : "Name must be at least 3 characters.");
            //    string nationalId = ReadString("National ID    : ", 14, v =>
            //    {
            //        if (!Regex.IsMatch(v, @"^\d{10,14}$")) return "National ID must be 10-14 digits.";
            //        if (db.Customers.Any(c => c.NationalId == v)) return "A customer with this National ID already exists.";
            //        return null;
            //    });
            //    DateTime dob = ReadDate("Date of Birth  : (yyyy-MM-dd) ");
            //    string email = ReadString("Email          : ", 150, v => IsValidEmail(v) ? null : "Invalid email format.");
            //    string phone = ReadString("Phone          : ", 20, v => Regex.IsMatch(v, @"^\+?\d{7,15}$") ? null : "Phone must be 7-15 digits (optional leading +).");
            //    string address = ReadString("Address        : ", 200, v => v.Length >= 5 ? null : "Address is too short.");
            //    var type = ReadEnum<CustomerType>("Customer Type:");

            //    var customer = new Customer
            //    {
            //        FullName = fullName,
            //        NationalId = nationalId,
            //        DateOfBirth = dob,
            //        Email = email,
            //        PhoneNumber = phone,
            //        Address = address,
            //        CustomerType = type
            //    };
            //    db.Customers.Add(customer);
            //    db.SaveChanges();

            //    Success($"Customer created successfully. CustomerId = {customer.Id}");
            //}

            //// ======================================================================
            //// 2) Open Account
            //// ======================================================================
            //void OpenAccount()
            //{
            //    Console.WriteLine("--- Open New Account ---");

            //    string accountNumber = ReadString("Account Number : ", 20, v => Regex.IsMatch(v, @"^[A-Za-z0-9\-]+$") ? null : "Use letters, digits and '-' only.");
            //    var accountType = ReadEnum<AccountType>("Account Type:");
            //    string branchCode = ReadString("Branch Code    : ", 10, _ => null).ToUpperInvariant();
            //    int customerId = ReadInt("Customer Id    : ");
            //    var ownership = ReadEnum<OwnershipType>("Ownership Role:");

            //    Info($"Validating branch '{branchCode}' and customer #{customerId}...");

            //    var branch = db.Branches.FirstOrDefault(b => b.Code == branchCode);
            //    if (branch is null) { Error($"Branch '{branchCode}' does not exist."); return; }

            //    var customer = db.Customers.Find(customerId);
            //    if (customer is null) { Error($"Customer #{customerId} does not exist."); return; }

            //    var account = db.Accounts.Include(a => a.CustomerAccounts).FirstOrDefault(a => a.AccountNumber == accountNumber);

            //    if (account is null)
            //    {
            //        if (ownership != OwnershipType.Primary)
            //        {
            //            Error("A new account must be opened with a Primary owner first.");
            //            return;
            //        }
            //        account = new Account
            //        {
            //            AccountNumber = accountNumber,
            //            AccountType = accountType,
            //            BranchCode = branchCode,
            //            CurrentBalance = 0m,
            //            OpeningDate = DateTime.Today
            //        };
            //        db.Accounts.Add(account);
            //    }
            //    else
            //    {
            //        if (ownership != OwnershipType.CoHolder)
            //        {
            //            Error($"Account '{accountNumber}' already exists. Use the CoHolder role to share it.");
            //            return;
            //        }
            //        if (account.CustomerAccounts.Any(ca => ca.CustomerId == customerId))
            //        {
            //            Error($"Customer #{customerId} is already linked to account '{accountNumber}'.");
            //            return;
            //        }
            //        if (account.BranchCode != branchCode || account.AccountType != accountType)
            //        {
            //            Error("Branch code / account type do not match the existing account.");
            //            return;
            //        }
            //    }

            //    db.CustomerAccounts.Add(new CustomerAccount
            //    {
            //        CustomerId = customerId,
            //        AccountNumber = accountNumber,
            //        OwnershipType = ownership,
            //        OwnershipStartDate = DateTime.Today,
            //        AccountStatus = AccountStatus.Active
            //    });
            //    db.SaveChanges();

            //    Success($"Account '{accountNumber}' created and linked to customer {customerId} as {ownership} owner.");
            //}

            //// ======================================================================
            //// 3) Update Account Status
            //// ======================================================================
            //void UpdateAccountStatus()
            //{
            //    Console.WriteLine("--- Update Account Status ---");

            //    string accountNumber = ReadString("Account Number : ", 20, _ => null);
            //    int customerId = ReadInt("Customer Id    : ");

            //    var link = db.CustomerAccounts.Find(customerId, accountNumber);
            //    if (link is null) { Error("No link found between this customer and account."); return; }

            //    var newStatus = ReadEnum<AccountStatus>("New Status:");
            //    if (link.AccountStatus == newStatus)
            //    {
            //        Info($"Status is already {newStatus}. Nothing to change.");
            //        return;
            //    }

            //    link.AccountStatus = newStatus;
            //    db.SaveChanges();
            //    Success($"Status updated to {newStatus}.");
            //}

            //// ======================================================================
            //// 4) Remove an Account from a Customer
            //// ======================================================================
            //void RemoveAccountFromCustomer()
            //{
            //    Console.WriteLine("--- Remove Account From Customer ---");

            //    string accountNumber = ReadString("Account Number : ", 20, _ => null);
            //    int customerId = ReadInt("Customer Id    : ");

            //    var link = db.CustomerAccounts.Find(customerId, accountNumber);
            //    if (link is null) { Error("No link found between this customer and account."); return; }

            //    int owners = db.CustomerAccounts.Count(ca => ca.AccountNumber == accountNumber);
            //    bool lastOwner = owners == 1;

            //    if (lastOwner && db.Transactions.Any(t => t.AccountNumber == accountNumber))
            //    {
            //        Error("Cannot remove the last owner: the account has transaction history that must be kept.");
            //        return;
            //    }

            //    db.CustomerAccounts.Remove(link);

            //    if (lastOwner)
            //    {
            //        var account = db.Accounts.Find(accountNumber)!;
            //        db.Accounts.Remove(account);
            //    }
            //    db.SaveChanges();

            //    Success("Ownership link deleted.");
            //    if (lastOwner) Info($"    That was the last owner - account '{accountNumber}' was also removed.");
            //}

            //// ======================================================================
            //// 5) List all Customers (Eager Loading)
            //// ======================================================================
            //void ListCustomers()
            //{
            //    Console.WriteLine("--- All Customers ---");
            //    Console.WriteLine();

            //    var customers = db.Customers
            //        .AsNoTracking()
            //        .Include(c => c.CustomerAccounts)
            //            .ThenInclude(ca => ca.Account)
            //                .ThenInclude(a => a.Branch)
            //        .OrderBy(c => c.Id)
            //        .ToList();

            //    if (customers.Count == 0) { Console.WriteLine("  (no customers yet)"); return; }

            //    foreach (var c in customers)
            //    {
            //        Console.WriteLine($"  #{c.Id} {c.FullName} ({c.CustomerType})");
            //        if (c.CustomerAccounts.Count == 0)
            //        {
            //            Console.WriteLine("      (no accounts)");
            //            continue;
            //        }
            //        foreach (var ca in c.CustomerAccounts)
            //        {
            //            var a = ca.Account;
            //            Console.WriteLine(
            //                $"      {a.AccountNumber,-10} {a.AccountType,-9} Balance: {a.CurrentBalance,12:N2}   " +
            //                $"{ca.OwnershipType,-9} {ca.AccountStatus,-7} @ {a.Branch.Name}");
            //        }
            //    }
            //}

            //// ======================================================================
            //// Input helpers - never throw on bad input, keep asking
            //// ======================================================================
            //static string ReadString(string prompt, int maxLength, Func<string, string?> validate)
            //{
            //    while (true)
            //    {
            //        Console.Write(prompt);
            //        var input = Console.ReadLine()?.Trim() ?? "";
            //        if (input.Length == 0) { Error("This field is required."); continue; }
            //        if (input.Length > maxLength) { Error($"Maximum length is {maxLength} characters."); continue; }
            //        var problem = validate(input);
            //        if (problem is null) return input;
            //        Error(problem);
            //    }
            //}

            //static int ReadInt(string prompt)
            //{
            //    while (true)
            //    {
            //        Console.Write(prompt);
            //        if (int.TryParse(Console.ReadLine(), out int value) && value > 0) return value;
            //        Error("Please enter a valid positive number.");
            //    }
            //}

            //static DateTime ReadDate(string prompt)
            //{
            //    while (true)
            //    {
            //        Console.Write(prompt);
            //        if (DateTime.TryParseExact(Console.ReadLine()?.Trim(), "yyyy-MM-dd",
            //                CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            //        {
            //            if (date > DateTime.Today) { Error("Date of birth cannot be in the future."); continue; }
            //            if (date < DateTime.Today.AddYears(-120)) { Error("Date of birth is not realistic."); continue; }
            //            return date;
            //        }
            //        Error("Invalid date. Use the format yyyy-MM-dd (e.g. 2000-01-25).");
            //    }
            //}

            //static T ReadEnum<T>(string title) where T : struct, Enum
            //{
            //    var values = Enum.GetValues<T>();
            //    while (true)
            //    {
            //        Console.WriteLine(title);
            //        foreach (var v in values) Console.WriteLine($"    {Convert.ToInt32(v)}) {v}");
            //        Console.Write("  Choice: ");
            //        if (int.TryParse(Console.ReadLine(), out int n) && Enum.IsDefined(typeof(T), n))
            //            return (T)Enum.ToObject(typeof(T), n);
            //        Error("Invalid choice, please pick one of the listed numbers.");
            //    }
            //}

            //static bool IsValidEmail(string email)
            //{
            //    try { return new MailAddress(email).Address == email && email.Contains('.'); }
            //    catch { return false; }
            //}

            //static void Success(string msg) => Print(msg, ConsoleColor.Green);
            //static void Error(string msg) => Print(msg, ConsoleColor.Red);
            //static void Info(string msg) => Print(msg, ConsoleColor.Cyan);

            //static void Print(string msg, ConsoleColor color)
            //{
            //    var old = Console.ForegroundColor;
            //    Console.ForegroundColor = color;
            //    Console.WriteLine(msg);
            //    Console.ForegroundColor = old;
            //}

            #endregion

        }
    }
}
