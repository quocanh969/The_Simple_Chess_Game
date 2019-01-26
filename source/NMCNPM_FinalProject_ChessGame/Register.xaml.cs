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
using System.Windows.Shapes;
using DTO;
using BUS;

namespace NMCNPM_FinalProject_ChessGame
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {// Thoát chương trình khi người dùng ấn CANCEL
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {// Xử lý nạp chương trình khi người dùng ấn OK
            if (txtConfirm.Password.Count() == 0 || txtEmail.Text.Count() == 0 || txtID.Text.Count() == 0 || txtName.Text.Count() == 0 || txtPass.Password.Count() == 0)
            {
                lblNotice.Content = "Please fill all information.";
                lblNotice.Visibility = Visibility.Visible;
                return;
            }

            UserDTO user = new UserDTO();
            user.name = txtName.Text.Trim();
            user.id = txtID.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.password = txtPass.Password.Trim();
            string confirm = txtConfirm.Password.Trim();


            // Check password and confirm
            if (string.Compare(user.password, confirm, true) != 0)
            {
                lblNotice.Content = "Password confirm was wrong";
                lblNotice.Visibility = Visibility.Visible;
                return;
            }

            //Register
            UserBUS bus = new UserBUS();
            int result = bus.Register(user);
            if (result == 0)
            {
                lblNotice.Content = "Register's Failed";
                lblNotice.Visibility = Visibility.Visible;
            }
            else if (result == 1)
            {
                lblNotice.Content = "Register success";
                lblNotice.Visibility = Visibility.Visible;
                this.Close();
            }
            else
            {
                lblNotice.Content = "ID was existed";
                lblNotice.Visibility = Visibility.Visible;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {// Xử lý khi mà tắt cửa sổ này
            GlobalItem.isRegisterOpen = false;
        }
    }
}
