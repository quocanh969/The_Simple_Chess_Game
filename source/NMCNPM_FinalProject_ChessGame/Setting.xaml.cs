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


namespace NMCNPM_FinalProject_ChessGame
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
     
        private bool isAniAudio = true;

        private List<TypeOfMatch> lstType;

        public Setting()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {// Xử lý sự kiện drag window
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

     

        private void btnAniAudio_Click(object sender, RoutedEventArgs e)
        {// Xử lý sự kiên ấn vào button Animation Audio
            if (isAniAudio)
            {
                imgAniAudio.Source = new BitmapImage(new Uri("Source/MainScreen/Volume_Off.png", UriKind.Relative));
                isAniAudio = false;
            }
            else
            {
                imgAniAudio.Source = new BitmapImage(new Uri("Source/MainScreen/Volume_On.png", UriKind.Relative));
                isAniAudio = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {// Xử lý sự kiện ấn vào button exit
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {// Xử lý khi tát cửa sổ
            GlobalItem.isSettingOpen = false;

            if (cmbTypeOfMatch.SelectedItem != null)
            {
                TypeOfMatch temp = lstType[cmbTypeOfMatch.SelectedIndex];

                GlobalItem.isAudio = isAniAudio;

                GlobalItem.typePlayer1 = new SolidColorBrush(Color.FromRgb(temp.r1, temp.g1, temp.b1));
                GlobalItem.typePlayer2 = new SolidColorBrush(Color.FromRgb(temp.r2, temp.g2, temp.b2));

                GlobalItem.Source = temp.source;
            }
        }

        // Init List Type
        private void InitListType()
        {
            lstType = new List<TypeOfMatch>()
            {
                 new TypeOfMatch() { name = "Classic",
                     r1 = 200, g1 = 226, b1 = 177, r2 = 255, g2 = 255, b2 = 255,
                    source = "Source/Gameplay_Background/classic.jpg"},
                 new TypeOfMatch() { name = "Hall of fame",
                     r1 = 160, g1 = 82, b1 = 45, r2 = 255, g2 = 228, b2 = 181,
                    source = "Source/Gameplay_Background/hall_of_fame.jpg"},

                  new TypeOfMatch() { name = "Marsh mallow",
                     r1 = 250, g1 = 128, b1 = 114, r2 = 255, g2 = 240, b2 = 245,
                    source = "Source/Gameplay_Background/mash_mallow.jpg"},
                 new TypeOfMatch() { name = "Inferno",
                     r1 = 69, g1 = 102, b1 = 142, r2 = 246, g2 = 124, b2 = 26,
                    source = "Source/Gameplay_Background/inferno.jpg"},
                 new TypeOfMatch() { name = "Leaf",
                     r1 = 34, g1 = 139, b1 = 34, r2 = 255, g2 = 246, b2 = 143,
                    source = "Source/Gameplay_Background/leaf.jpg"},
                 new TypeOfMatch() { name = "Ice Age",
                     r1 = 209, g1 = 238, b1 = 238, r2 = 95, g2 = 158, b2 = 160,
                    source = "Source/Gameplay_Background/ice_age.jpg"},
                 new TypeOfMatch() { name = "Light",
                     r1 = 205, g1 = 205, b1 = 193, r2 = 139, g2 = 139, b2 = 131,
                    source = "Source/Gameplay_Background/light.png"},
                 new TypeOfMatch() { name = "Dawn",
                     r1 = 105, g1 = 89, b1 = 205, r2 = 255, g2 = 240, b2 = 245,
                    source = "Source/Gameplay_Background/lavender.jpg"},
                 new TypeOfMatch() { name = "Sand",
                     r1 = 205, g1 = 183, b1 = 181, r2 = 255, g2 = 255, b2 = 255,
                    source = "Source/Gameplay_Background/sand.jpg"},
                 new TypeOfMatch() { name = "Sky",
                     r1 = 193, g1 = 205, b1 = 193, r2 = 255, g2 = 255, b2 = 255,
                    source = "Source/Gameplay_Background/sky.jpg"},


            };
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            InitListType();
            cmbTypeOfMatch.ItemsSource = lstType;
            cmbTypeOfMatch.SelectedItem = lstType[0];
        }
    }
}
