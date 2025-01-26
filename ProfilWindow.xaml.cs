﻿using System;
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
using System.Windows.Shapes;

namespace BetApplication
{
    public partial class ProfilWindow : Window
    {
        User user;
        AuthenticationSystem a;
        public ProfilWindow(User u, AuthenticationSystem a)
        {
            user = u;
            this.a = a;
            InitializeComponent();
            Login.Content = u.Login;
            Balance.Text = u.BalanceString(u.Balance);
            CouponList.ItemsSource = user.currentCoupons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recharge RW = new Recharge(user);
            RW.BalanceUpdated += () =>
            {
                Balance.Text = user.Balance.ToString();
            };
            RW.Show();
        }
        private void Comeback_Click(object sender, RoutedEventArgs e)
        {
            BettingWindow BetW = new BettingWindow(user, a);
            BetW.Show();  
            this.Close();
        }

        private void SettleTheBet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Coupon selectedC = CouponList.SelectedItem as Coupon;
                selectedC.EndCoupon();
                user.currentCoupons.Remove(selectedC);
            }
            catch (Exception ex) { }
        }
        
    }
}
