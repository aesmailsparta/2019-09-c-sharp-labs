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

namespace MiniBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Customer LoggedInCustomer = null;
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
            //NewAccount.IsSelected = true;
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
            //Validate Input
            //Verify Customer Details
            //Add New Account To Customer(£50)
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
            //Clear Logged In Details
            LoginWelcomeMessage.Text = "";
            //Disable Customer Functions
            mNavDashboard_Button.IsEnabled = false;
            mNavWithdraw_Button.IsEnabled = false;
            mNavDeposit_Button.IsEnabled = false;
        }

        private void WithdrawMoney()
        {
            //Validate Input
            //Verify Customer And Account
            //Verify Availability Of Funds
            //Withdraw Money From Account
        }

        private void DepositMoney()
        {
            //Validate Input
            //Verify Customer And Account
            //Deposit Money Into Account
        }

        private void Btn_AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateNewBankCustomer();
        }

        private void Btn_LoginCustomer_Click(object sender, RoutedEventArgs e)
        {
            LoginCustomer();
        }

        private void TabController_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
