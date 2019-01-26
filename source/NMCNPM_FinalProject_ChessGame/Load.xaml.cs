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
    /// Interaction logic for Load.xaml
    /// </summary>
    public partial class Load : Window
    {
        List<PlayerInfo> listOfMatchInfo = new List<PlayerInfo>();
        int count = 0;
        bool temp;

        public Load()
        {
            InitializeComponent();
            loadLoadScreen();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {// Xử lý khi người dùng nhấn vào một item trong màn hình match
            // Lấy dữ liệu từ list view
            ListViewItem lvi = sender as ListViewItem;
            Matches selectedMatches = lvi.DataContext as Matches;

            // Nếu dữ liệu đọc vào không rỗng
            if (selectedMatches != null)
            {
                temp = new bool();
                temp = true;
                GlobalItem.isAnyMatchInfo.Add(temp);

                MatchInfo MatchInfoScreen = new MatchInfo(selectedMatches.id, count);
                count++;
                MatchInfoScreen.Show();
                MatchInfoScreen.Owner = this;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // Xử lý khi tắt cửa 
            if (listOfMatchInfo != null)
            {
                for (int i = 0; i < listOfMatchInfo.Count(); i++)
                {
                    if (GlobalItem.isAnyMatchInfo[i] == true)
                    {
                        listOfMatchInfo[i].Close();
                    }
                }
            }
            GlobalItem.isLoadOpen = false;
        }

        private void loadLoadScreen()
        {
            MatchBUS bus = new MatchBUS();
            List<Matches> list = new List<Matches>();
            List<MatchDTO> matches = bus.loadAllSavedMatch();

            for (int i = 0; i < matches.Count(); i++)
            {
                list.Add(new Matches() { stt = i + 1, id = matches[i].id });
            }
            lstMatch.ItemsSource = list;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
