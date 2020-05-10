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
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Program_do_nauki
{
    /// <summary>
    /// Logika interakcji dla klasy Zapisz.xaml
    /// </summary>
    public partial class Zapisz : Window
    {
        public Zapisz()
        {
            InitializeComponent();
        }

        public Zapisz(Slowa sl, string lok)
        {
            InitializeComponent();
            baza = sl;

            if(lok!="")
            {
                lokalizacja = lok;
                tbx_saveas.Text = lok;
            }
            else
            {
                lokalizacja = "";
                btn_save.IsEnabled = false;
                tbx_saveas.Text = "";
            }
            CenterWindowOnScreen();
        }

        public Slowa baza = new Slowa();
        private string lokalizacja = "";


        private void Save()
        {
            try
            {
                Stream stream = File.OpenWrite(lokalizacja + ".pdbl");
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, baza);


                stream.Flush();
                stream.Close();
                stream.Dispose();
            }
            catch
            {
                MessageBox.Show("Błąd podczas zapisywania!");
            }
        }


        //stara serializacja do xml
        //private void Save()
        //{
        //    try
        //    {
        //        FileStream str = new FileStream(lokalizacja + ".xml", FileMode.Create); 
        //        XmlSerializer serializer = new XmlSerializer(typeof(Slowa));        


        //        serializer.Serialize(str, baza);      

        //        str.Close();            
        //    }
        //    catch                     
        //    {
        //        MessageBox.Show("Błąd podczas zapisywania!");       
        //    }
        //}


        public string getLokalizacja()
        {
            return lokalizacja;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            if(lokalizacja !="")
            {
                Save();
                this.Close();
            }

        }

        private void Btn_saveas_Click(object sender, RoutedEventArgs e)
        {
            lokalizacja = tbx_saveas.Text;
            Save();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void tbx_saveas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                Btn_saveas_Click(sender, e);
            }
            if (e.Key == Key.Escape)                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                btn_anuluj_Click(sender, e);
            }
        }

        private void btn_anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
