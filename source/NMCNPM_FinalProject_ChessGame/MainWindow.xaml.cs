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
using DTO;
using BUS;
using System.Media;



namespace NMCNPM_FinalProject_ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tham chiếu các cửa sổ
        Register ResgisterScreen;
        Rank RankScreen;
        Setting SettingScreen;
        Login player_1_login;
        Load LoadScreen;





        public MainWindow()
        {
            GlobalItem.main = this;



            InitializeComponent();
        }



        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button QUIT

            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button REGISTER

            if (GlobalItem.isRegisterOpen == false)
            {// Kiểm tra xem đã có màn hình Register nào bật chưa
                GlobalItem.isRegisterOpen = true;
                ResgisterScreen = new Register();
                ResgisterScreen.Show();
            }
        }

        private void btnRank_Click(object sender, RoutedEventArgs e)
        {// Xứ lý khi ấn button RANk

            if (GlobalItem.isRankOpen == false)
            {// Kiểm tra xem đã có màn hình RANK nào bật chưa
                GlobalItem.isRankOpen = true;
                RankScreen = new Rank();
                RankScreen.Show();
            }
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button SETTING
            if (GlobalItem.isSettingOpen == false)
            {// Kiểm tra xem đã có màn hình SETTING nào bật chua
                GlobalItem.isSettingOpen = true;
                SettingScreen = new Setting();
                SettingScreen.Show();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {// Xử lý sự kiến khi ấn button NEW
            player_1_login = new Login(1);
            player_1_login.ShowDialog();
            if (GlobalItem.isPlayer1LoingOK == false)
            {
                 return;
            }

           Login player_2_login = new Login(2);
           player_2_login.ShowDialog();
           if (GlobalItem.isPlayer2LoingOK == false)
           {
               return;
           }

           MatchSetting settingMatch = new MatchSetting();
           settingMatch.ShowDialog();
           



            // Sau khi đăng nhập thành công thì cửa sổ đăng nhập sẽ thoát
            //tiếp tục hiện ra màn hình ván đấu ở màn hình chính
            UCPlayground.Visibility = Visibility.Visible; // Hiển thị ra màn hình play game
            UCPlayground.setTime(); // Hàm cập nhật thời gian đếm ngược
            UCPlayground.initCinemaSeats(); // Hàm tái khởi tạo CinemaSeats
            UCPlayground.itPlayTime(); // Bắt đầu thời gian đếm ngược
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {// Xử lý khi ấn button LOAD
            if (GlobalItem.isLoadOpen == false)
            {// Kiểm tra xem đã có màn hình Load nào bật chua
                GlobalItem.isLoadOpen = true;
                LoadScreen = new Load();
                LoadScreen.Show();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            // Tắt tất cả màn hình nếu chúng có mỏ
            if (GlobalItem.isRegisterOpen == true)
            {
                ResgisterScreen.Close();
            }
            if (GlobalItem.isRankOpen == true)
            {
                RankScreen.Close();
            }
            if (GlobalItem.isSettingOpen == true)
            {
                SettingScreen.Close();
            }
            if (GlobalItem.isLoadOpen == true)
            {
                LoadScreen.Close();
            }

            this.Close();
        }
    }
}
