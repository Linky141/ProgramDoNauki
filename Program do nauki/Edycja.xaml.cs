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

namespace Program_do_nauki
{
    /// <summary>
    /// Logika interakcji dla klasy Edycja.xaml
    /// </summary>
    public partial class Edycja : Window
    {
        public Edycja()
        {
            InitializeComponent();
            Czyszczenie();
            CenterWindowOnScreen();
        }

        public List<string> definicje = new List<string>();
        public List<string> opisy = new List<string>();

        public Edycja(List<string> d, List<string> o)
        {
            InitializeComponent();
            Czyszczenie();
            definicje = d;
            opisy = o;
            OdswierzanieListboxa();
        }

        public void Czyszczenie()
        {
            tbx_def.Text = "";
            tbx_opi.Text = "";
            lbx_def.Items.Clear();
        }

        public void OdswierzanieListboxa()
        {
            try
            {  
                lbx_def.Items.Clear();                                                                      
                foreach (var val in definicje) lbx_def.Items.Add(val);                                     
            }
            catch
            { MessageBox.Show("error"); }
            tbx_def.Text = "";
            tbx_opi.Text = "";
        }

        private void Btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if(tbx_def.Text != "" && tbx_opi.Text != "")
            definicje.Add(tbx_def.Text);
            opisy.Add(tbx_opi.Text);
            OdswierzanieListboxa();
        }

        private void Btn_usun_Click(object sender, RoutedEventArgs e)
        {
            int id = lbx_def.SelectedIndex;
            try
            {
                definicje.Remove(definicje[id]);
                opisy.Remove(opisy[id]);
                OdswierzanieListboxa();
            }
            catch { MessageBox.Show("Błąd podczas kasowania"); }
        }


        public List<string> getOpisy()
        {
            return opisy;
        }

        public List<string> getDefinicje()
        {
            return definicje;
        }

        private void tbx_opi_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Return)
            {
                Btn_dodaj_Click(sender, e);
            }
        }

        private void tbx_def_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_dodaj_Click(sender, e);
            }
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
