using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace MiniBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Customer LoggedInCustomer = null;
        static Account currentActiveAccount = null;
        static List<Account> CustomerAccounts = new List<Account>();
        static List<Bank_Transaction> customerTransactions = new List<Bank_Transaction>();
        public MainWindow()
        {
            InitializeComponent();
            initialise();
        }

        private void initialise()
        {
            mNavDashboard_Button.IsEnabled = false;
            mNavWithdraw_Button.IsEnabled = false;
            mNavDeposit_Button.IsEnabled = false;
        }


        private void NavHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home.IsSelected = true;
        }
        private void NavNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer.IsSelected = true;
        }
        private void NavNewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            NewAccount.IsSelected = true;
        }
        private void NavLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (mNavLogin_Button.Content.Equals("Login")) {
                Login.IsSelected = true;
            }
            else
            {
                LogoutCustomer();
                mNavLogin_Button.Content = "Login";
            }
        }
        private void NavDashboardButton_Click(object sender, RoutedEventArgs e)
        {
            Dashboard.IsSelected = true;
        }
        private void NavWithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            Withdraw.IsSelected = true;
        }
        private void NavDepositButton_Click(object sender, RoutedEventArgs e)
        {
            Deposit.IsSelected = true;
        }

        private void CreateNewBankCustomer()
        {
            nError.Foreground = Brushes.PaleVioletRed;
            bool IsValidInput = true;

            //Validate Input
            if (nCustomerName.Text.Length <= 0)
            {
                nError.Text = "Please enter a Customer Name\n";
                IsValidInput = false;
            }
            else if (nCustomerTel.Text.Length <= 0)
            {
                nError.Text = "Please enter a Customer Telephone Number\n";
                IsValidInput = false;
            }
            else if (nCustomerEmail.Text.Length <= 0)
            {
                nError.Text = "Please enter a Customer Email\n";
                IsValidInput = false;
            }
            else if (nCustomerPIN.Password.Length < 4)
            {
                nError.Text = "Please enter a PIN of at least 4 characters\n";
                IsValidInput = false;
            }
            else if (nCustomerPIN.Password != nCustomerPINConfirm.Password)
            {
                nError.Text = "Your PINs do not match\n";
                IsValidInput = false;
            }

            if (IsValidInput)
            {
                //Add Customer To Database
                using (var db = new MiniBankEntities())
                {
                    Random r = new Random();

                    var CustomerToAdd = new Customer
                    {
                        Name = nCustomerName.Text,
                        PhoneNumber = nCustomerTel.Text,
                        Email = nCustomerEmail.Text,
                        PIN = nCustomerPIN.Password
                    };

                    Customer newCustomer = null;
                    db.Customers.Add(CustomerToAdd);
                    db.SaveChanges();

                    newCustomer = db.Customers.OrderByDescending(c => c.CustomerID).FirstOrDefault();

                    if (newCustomer != null) {

                        var AccountToAdd = new Account
                        {
                            CustomerID = newCustomer.CustomerID,
                            AccountNumber = r.Next(999999).ToString(),
                            Amount = 50
                        };

                        db.Accounts.Add(AccountToAdd);
                    }

                    db.SaveChanges();
                }

                nError.Text = $"Welcome to MINIBANK {nCustomerName.Text}, We hope you enjoy your time with us.";
                nError.Foreground = Brushes.LightGreen;

                nCustomerName.Text = "";
                nCustomerTel.Text = "";
                nCustomerEmail.Text = "";
                nCustomerPIN.Password = "";
                nCustomerPINConfirm.Password = "";

            }
        }

        private void CreateNewAccount()
        {
            newAccountError.Text = "";
            newAccountError.Foreground = Brushes.PaleVioletRed;
            bool IsValidInput = true;
            //Validate Input
            if (accountCustomerName.Text.Length <= 0)
            {
                newAccountError.Text = "An Account Holder Name must be entered";
                IsValidInput = false;
            }
            else if (accountCustomerPIN.Password.Length == 0)
            {
                newAccountError.Text = "Please enter your Account PIN\n";
                IsValidInput = false;
            }
            else if (accountCustomerPIN.Password.Length < 4)
            {
                newAccountError.Text = "The PIN you entered is too short\n";
                IsValidInput = false;
            }

            if (IsValidInput)
            {
                Random r = new Random();
                //Verify Customer Login Details
                using (var db = new MiniBankEntities())
                {
                    Customer CustomerToAssignNewAccount = db.Customers.Where(c => c.Name == accountCustomerName.Text && c.PIN == accountCustomerPIN.Password)
                           .FirstOrDefault<Customer>();

                    //Login Customer
                    if (CustomerToAssignNewAccount != null)
                    {
                        var AccountToAdd = new Account
                        {
                            CustomerID = CustomerToAssignNewAccount.CustomerID,
                            AccountNumber = r.Next(999999).ToString(),
                            Amount = 50
                        };

                        db.Accounts.Add(AccountToAdd);

                        db.SaveChanges();

                        accountCustomerName.Text = "";
                        accountCustomerPIN.Password = "";

                        if (LoggedInCustomer != null)
                        {
                            getCustomerAccounts(LoggedInCustomer);

                            CustomerAccountsList.ItemsSource = CustomerAccounts;
                        }
                        newAccountError.Text = $"A new account for {CustomerToAssignNewAccount.Name} has been added successfully";
                        newAccountError.Foreground = Brushes.LightGreen;
                    }
                    else
                    {
                        newAccountError.Text = "Ooops.. Name/Password is incorrect";
                    }
                }
            }
            //Validate Input
            //Verify Customer Details
            //Add New Account To Customer(£50)
        }

        private void getCustomerAccounts(Customer customer)
        {
            if (customer != null)
            {//Add Customer To Database
                using (var db = new MiniBankEntities())
                {
                    CustomerAccounts = db.Accounts.Where(a => a.CustomerID == customer.CustomerID).ToList();
                }
            }
        }

        private void LoginCustomer()
        {
            loginError.Text = "";
            bool IsValidInput = true;
            bool LoginSuccess = false;
            //Validate Input
            if (loginName.Text.Length <= 0)
            {
                loginError.Text = "An Account Holder Name must be entered";
                IsValidInput = false;
            }
            else if (loginPIN.Password.Length == 0)
            {
                loginError.Text = "Please enter your Account PIN\n";
                IsValidInput = false;
            }
            else if (loginPIN.Password.Length < 4)
            {
                loginError.Text = "The PIN you entered is too short\n";
                IsValidInput = false;
            }

            if (IsValidInput)
            {
                //Verify Customer Login Details
                using (var db = new MiniBankEntities())
                {
                    Customer CustomerToLogin = db.Customers.Where(c => c.Name == loginName.Text && c.PIN == loginPIN.Password)
                           .FirstOrDefault<Customer>();

                    //Login Customer
                    if (CustomerToLogin != null)
                    {
                        LoginSuccess = true;
                        //Activate Customer Functions
                        mNavDashboard_Button.IsEnabled = true;
                        mNavWithdraw_Button.IsEnabled = true;
                        mNavDeposit_Button.IsEnabled = true;
                        mNavLogin_Button.Content = "Logout";

                        LoggedInCustomer = CustomerToLogin;

                        LoginWelcomeMessage.Text = $"Welcome {LoggedInCustomer.Name}";

                        loginName.Text = "";
                        loginPIN.Password = "";

                        DashboardTitle.Content = $"{LoggedInCustomer.Name}'s Dashboard";

                        getCustomerAccounts(CustomerToLogin);

                        GetTransactionHistory();

                        CustomerAccountsList.ItemsSource = CustomerAccounts;
                    }
                }

                if (LoginSuccess)
                {
                    //GOTO HomePage
                    Home.IsSelected = true;
                }
                else
                {
                    loginError.Text = "Ooops.. Name/Password is incorrect";
                }
            }
        }

        private void LogoutCustomer()
        {
            //LogoutCustomer
            LoggedInCustomer = null;
            CustomerAccounts = null;
            CustomerAccountsList.ItemsSource = CustomerAccounts;
            customerTransactions = null;
            CustomerTransactions.ItemsSource = customerTransactions;
            //Clear Logged In Details
            LoginWelcomeMessage.Text = "";
            DashboardTitle.Content = $"Dashboard";
            //Disable Customer Functions
            mNavDashboard_Button.IsEnabled = false;
            mNavWithdraw_Button.IsEnabled = false;
            mNavDeposit_Button.IsEnabled = false;
        }

        private void WithdrawMoney()
        {
            //***********Add Foreign Transactions**********
            wError.Foreground = Brushes.PaleVioletRed;
            bool IsValidInput = true;
            int.TryParse(wAccountNumber.Text, out int accNumber);
            int.TryParse(wAmount.Text, out int amountToWithdraw);

            //Validate Input
            if (wCustomerPIN.Password.Length < 4)
            {
                wError.Text = "Please enter a valid PIN";
            }
            else if ((wAccountNumber.Text.Length <= 0) || (accNumber <= 0))
            {
                wError.Text = "Please enter a valid Account Number";
            }
            else if ((wAmount.Text.Length <= 0) || (amountToWithdraw <= 0))
            {
                wError.Text = "Please enter a valid Amount to Withdraw";
            }
            else
            {
                using (var db = new MiniBankEntities()) {

                    currentActiveAccount =
                        db.Accounts.Where(a => a.CustomerID == LoggedInCustomer.CustomerID && a.AccountNumber == wAccountNumber.Text).FirstOrDefault();

                    if (db.Customers.Any(c => c.CustomerID == LoggedInCustomer.CustomerID && c.PIN == wCustomerPIN.Password)) {

                        if (currentActiveAccount != null) {

                           if (currentActiveAccount.Amount > amountToWithdraw)
                            {
                                int previousBalance = (int)currentActiveAccount.Amount;
                                currentActiveAccount.Amount -= amountToWithdraw;

                                Bank_Transaction transaction = new Bank_Transaction
                                {
                                    Amount = amountToWithdraw,
                                    TransactionType = 1,
                                    AccountID = currentActiveAccount.AccountID,
                                    PreviousBalance = previousBalance,
                                    NewBalance = currentActiveAccount.Amount
                                };

                                db.Bank_Transaction.Add(transaction);

                                db.SaveChanges();

                                wCustomerPIN.Clear();
                                wAccountNumber.Clear();
                                wAmount.Clear();

                                if (LoggedInCustomer != null)
                                {
                                    getCustomerAccounts(LoggedInCustomer);
                                    CustomerAccountsList.ItemsSource = CustomerAccounts;
                                    GetTransactionHistory();
                                }

                                wError.Text = $"You have successfully withdrawn £{amountToWithdraw} from Account: {accNumber}";
                                wError.Foreground = Brushes.LightGreen;
                            }
                            else
                            {
                                wError.Text = "You do not have enough funds in your account to complete this transaction";
                            }

                        }
                        else
                        {
                            wError.Text = "Your account was not found, Please check your details and try again";
                        }


                        //Verify Customer And Account
                    }
                    else
                    {
                        wError.Text = "The PIN you entered was incorrect, please try again.";
                    }
                    //Verify Availability Of Funds
                    //Withdraw Money From Account
                }
            }
        }

        private void GetTransactionHistory()
        {
            if (LoggedInCustomer != null) {
                using (var db = new MiniBankEntities())
                {
                    var res = (from t in db.Bank_Transaction
                                            join a in db.Accounts
                                            on t.AccountID equals a.AccountID
                                            join c in db.Customers
                                            on a.CustomerID equals c.CustomerID
                                            join tt in db.TransactionTypes
                                            on t.TransactionType equals tt.TypeID
                                            where c.CustomerID == LoggedInCustomer.CustomerID
                               select new { t.TransactionID, t.Amount, t.NewBalance, t.PreviousBalance, a.AccountNumber, tt.TypeName }).OrderByDescending(t => t.TransactionID).ToList();

                    CustomerTransactions.ItemsSource = res;
                }
            }
        }

        private void DepositMoney()
        {
            dError.Foreground = Brushes.PaleVioletRed;
            bool IsValidInput = true;
            int.TryParse(dAccountNumber.Text, out int accNumber);
            int.TryParse(dAmount.Text, out int amountToDeposit);

            //Validate Input
            if (dCustomerPIN.Password.Length < 4)
            {
                dError.Text = "Please enter a valid PIN";
            }
            else if ((dAccountNumber.Text.Length <= 0) || (accNumber <= 0))
            {
                dError.Text = "Please enter a valid Account Number";
            }
            else if ((dAmount.Text.Length <= 0) || (amountToDeposit <= 0))
            {
                dError.Text = "Please enter a valid Amount to Deposit";
            }
            else
            {
                using (var db = new MiniBankEntities())
                {

                    //Verify Customer And Account
                    currentActiveAccount =
                        db.Accounts.Where(a => a.CustomerID == LoggedInCustomer.CustomerID && a.AccountNumber == dAccountNumber.Text).FirstOrDefault();

                    if (db.Customers.Any(c => c.CustomerID == LoggedInCustomer.CustomerID && c.PIN == dCustomerPIN.Password))
                    {

                        if (currentActiveAccount != null)
                        {
                            //Deposit Money Into Account
                            int previousBalance = (int)currentActiveAccount.Amount;
                            currentActiveAccount.Amount += amountToDeposit;

                            Bank_Transaction transaction = new Bank_Transaction
                            {
                                Amount = amountToDeposit,
                                TransactionType = 2,
                                AccountID = currentActiveAccount.AccountID,
                                PreviousBalance = previousBalance,
                                NewBalance = currentActiveAccount.Amount
                            };

                            db.Bank_Transaction.Add(transaction);

                            db.SaveChanges();

                            dCustomerPIN.Clear();
                            dAccountNumber.Clear();
                            dAmount.Clear();

                            if (LoggedInCustomer != null)
                            {
                                getCustomerAccounts(LoggedInCustomer);
                                CustomerAccountsList.ItemsSource = CustomerAccounts;
                                GetTransactionHistory();
                            }

                            dError.Text = $"You have successfully deposited £{amountToDeposit} into Account: {accNumber}";
                            dError.Foreground = Brushes.LightGreen;

                        }
                        else
                        {
                            dError.Text = "Your account was not found, Please check your details and try again";
                        }
                    }
                    else
                    {
                        dError.Text = "The PIN you entered was incorrect, please try again.";
                    }
                }
            }
        }

        private void Btn_AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateNewBankCustomer();
        }

        private void Btn_LoginCustomer_Click(object sender, RoutedEventArgs e)
        {
            LoginCustomer();
        }

        private void Btn_OpenNewAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateNewAccount();
        }

        private void Btn_Withdraw_Click(object sender, RoutedEventArgs e)
        {
            WithdrawMoney();
        }

        private void Btn_Deposit_Click(object sender, RoutedEventArgs e)
        {
            DepositMoney();
        }
    }
}
