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
    /// Logika interakcji dla klasy Wczytaj.xaml
    /// </summary>
    public partial class Wczytaj : Window
    {
        public Wczytaj()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }

        public Slowa baza = new Slowa();
        private string lokalizacja = "";


        private void Btn_wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Deserializacja();
            this.Close();
        }


        private void Deserializacja()
        {
            if (File.Exists(tbx_wczytaj.Text + ".pdbl"))                                                         //jeśli istnieje wybrany plik i jego lokalizacja
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream fs = File.Open(tbx_wczytaj.Text + ".pdbl", FileMode.Open);

                    Slowa temp = (Slowa)formatter.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();

                    baza = temp;
                    lokalizacja = tbx_wczytaj.Text;
                }
                catch                                                                                                   //jeśli wystąpi błąd
                {
                    MessageBox.Show("Nie można wczytać bazy z dysku!");                                                 //wyświetl komunikat                                                                           //odświerza wszystko
                }
            }
            else                                                                                                        //jeśli wybrany plik lub lokalizacja nie istnieje
            {
                MessageBox.Show("Nie można otworzyć pliku");
            }
        }

        //stara serializacja na xml
        //private void Deserializacja()
        //{
        //    if (File.Exists(tbx_wczytaj.Text))                                                         //jeśli istnieje wybrany plik i jego lokalizacja
        //    {
        //        try
        //        {
        //            FileStream str = new FileStream(tbx_wczytaj.Text, FileMode.Open);                  //otwarcie nowego strumienia plików w określonej lokalizacji dla bazy danych
        //            XmlSerializer serializer = new XmlSerializer(typeof(Slowa));                                //otwarcie serializera do określonego typu i strumienia dla bazy danych

        //            Slowa temp = (Slowa)serializer.Deserialize(str);                              //wykonanie deserializacji z pliku do tymczasowej listy
        //            str.Close();                                                                                        //zamknięcie strumienia

        //            baza = temp;
        //        }
        //        catch                                                                                                   //jeśli wystąpi błąd
        //        {
        //            MessageBox.Show("Nie można wczytać bazy z dysku!");                                                 //wyświetl komunikat                                                                           //odświerza wszystko
        //        }
        //    }
        //    else                                                                                                        //jeśli wybrany plik lub lokalizacja nie istnieje
        //    {
        //        MessageBox.Show("Nie można otworzyć pliku");
        //    }
        //}


        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }


        public Slowa getSlowa()
        {
            return baza;
        }

        public string getLokalizacja()
        {
            return lokalizacja;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btn_anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbx_wczytaj_KeyDown(object sender, KeyEventArgs e)
        {                  
            if (e.Key == Key.Return)                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                Btn_wczytaj_Click(sender, e);
            }
            if (e.Key == Key.Escape)                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                btn_anuluj_Click(sender, e);
            }
        }
    }
}
