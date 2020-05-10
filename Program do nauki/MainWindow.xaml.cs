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

namespace Program_do_nauki
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Czyszczenie();
            btn_losuj.IsEnabled = false;
            CenterWindowOnScreen();
            SetStartButtons();
        }

        Slowa baza = new Slowa();

        string mode = "nauka";
        int id = 0;
        string lokalizacja = "";
        bool show = true, ukrywaj = false;
        

        public void Czyszczenie()
        {
            lbl_def.Content = "";
            tbx_opis.Text = "";
            btn_nastepny.Content = ">";
            btn_poprzedni.Content = "<";
            btn_liczba.Content = "";
        }

        private void SetStartButtons()
        {
            btn_edytuj.IsEnabled = false;
            btn_mode.IsEnabled = false;
            btn_nastepny.IsEnabled = false;
            btn_poprzedni.IsEnabled = false;
            btn_liczba.IsEnabled = false;
            btn_show.IsEnabled = false;
            btn_losuj.IsEnabled = false;
            btn_zapisz.IsEnabled = false;
        }


        private void SetWorkingButtons()
        {
            if (mode == "nauka")
            {
                btn_edytuj.IsEnabled = true;
                btn_mode.IsEnabled = true;
                btn_nastepny.IsEnabled = true;
                btn_poprzedni.IsEnabled = true;
                btn_liczba.IsEnabled = true;
                btn_show.IsEnabled = true;
                btn_losuj.IsEnabled = false;
                btn_zapisz.IsEnabled = true;
            }
            if (mode == "test")
            {
                btn_edytuj.IsEnabled = true;
                btn_mode.IsEnabled = true;
                btn_nastepny.IsEnabled = false;
                btn_poprzedni.IsEnabled = false;
                btn_liczba.IsEnabled = false;
                btn_show.IsEnabled = true;
                btn_losuj.IsEnabled = true;
                btn_zapisz.IsEnabled = true;
            }
        }


        private void Btn_edytuj_Click(object sender, RoutedEventArgs e)
        {
            Edycja edit = new Edycja(baza.getDefinicja(), baza.getOpisy());
            edit.ShowDialog();

            baza.setDefinicja(edit.getDefinicje());
            baza.setOpis(edit.getOpisy());
            Czyszczenie();
            OdswierzanieNauka();

        }

        private void Btn_zapisz_Click(object sender, RoutedEventArgs e)
        {
            Zapisz save = new Zapisz(baza, lokalizacja);
            save.ShowDialog();
            if(save.getLokalizacja() != "" )lokalizacja = save.getLokalizacja();
            SetWorkingButtons();
        }

        private void Btn_wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Wczytaj load = new Wczytaj();
            load.ShowDialog();
            baza = load.getSlowa();
            if (load.getLokalizacja() != "") lokalizacja = load.getLokalizacja();
            Czyszczenie();

            btn_mode.Content = "Tryb: Nauka";
            btn_losuj.IsEnabled = false;
            btn_nastepny.IsEnabled = true;
            btn_poprzedni.IsEnabled = true;
            btn_liczba.IsEnabled = true;
            mode = "nauka";
            OdswierzanieNauka();
            if (load.getLokalizacja() != "") SetWorkingButtons();
            else SetStartButtons();
        }

       

        private void Btn_mode_Click(object sender, RoutedEventArgs e)
        {
            if(mode == "nauka")
            {
                btn_mode.Content = "Tryb: Test";

                if (ukrywaj == true)
                {
                    btn_show.Content = "Pokaż";
                    show = false;
                }
                else
                {
                    btn_show.Content = "Ukryj";
                    show = true;
                }

                btn_liczba.Content = "";
                btn_losuj.IsEnabled = true;
                btn_nastepny.IsEnabled = false;
                btn_poprzedni.IsEnabled = false;
                btn_liczba.IsEnabled = false;
                mode = "test";
                Czyszczenie();
            }
            else if(mode == "test")
            {
                btn_mode.Content = "Tryb: Nauka";

                if (ukrywaj == true)
                {
                    btn_show.Content = "Pokaż";
                    show = false;
                }
                else
                {
                    btn_show.Content = "Ukryj";
                    show = true;
                }

                btn_losuj.IsEnabled = false;
                btn_nastepny.IsEnabled = true;
                btn_poprzedni.IsEnabled = true;
                btn_liczba.IsEnabled = true;
                Czyszczenie();
                mode = "nauka";
                OdswierzanieNauka();
            }
        }

        private void btn_liczba_Click(object sender, RoutedEventArgs e)
        {
            if (id > 0)
            {
                try
                {
                    id = 0;
                    if (ukrywaj == false) tbx_opis.Text = baza.getOpisy(id);
                    else tbx_opis.Clear();
                    lbl_def.Content = baza.getDefinicja(id);
                    btn_liczba.Content = 1;
                    OdsiwerzUkrywanie();
                }
                catch { }
            }
            else if (id == 0)
            {
                try
                {
                    id = baza.getRozmiar()-1;
                    if (ukrywaj == false) tbx_opis.Text = baza.getOpisy(id);
                    else tbx_opis.Clear();
                    lbl_def.Content = baza.getDefinicja(id);
                    btn_liczba.Content = id+1;
                    OdsiwerzUkrywanie();
                }
                catch { }
            }
        }

        private void Btn_poprzedni_Click(object sender, RoutedEventArgs e)
        {
            if (id > 0)
            {
                try
                {
                    id -= 1;
                    if (ukrywaj == false) tbx_opis.Text = baza.getOpisy(id);
                    else tbx_opis.Clear();
                    lbl_def.Content = baza.getDefinicja(id);
                    btn_liczba.Content = id+1;
                    OdsiwerzUkrywanie();
                }
                catch {  }
            }
        }

        private void Btn_nastepny_Click(object sender, RoutedEventArgs e)
        {
            if (id < baza.getRozmiar()-1)
            {
                try
                {
                    id += 1;
                    btn_liczba.Content = id+1;
                    if (ukrywaj == false) tbx_opis.Text = baza.getOpisy(id);
                    else tbx_opis.Clear();
                    lbl_def.Content = baza.getDefinicja(id);
                    OdsiwerzUkrywanie();
                }
                catch {  }
            }
        }

        private void Btn_losuj_Click(object sender, RoutedEventArgs e)
        {
            Czyszczenie();
            try
            {
                System.Random x = new Random();
                id = x.Next(0, baza.getRozmiar());
                lbl_def.Content = baza.getDefinicja(id);
                if (ukrywaj == false) tbx_opis.Text = baza.getOpisy(id);
                OdsiwerzUkrywanie();
            }
            catch { }
        }

        private void OdswierzanieNauka()
        {
            if (mode == "nauka")
            {
                id = 0;
                try
                {
                    tbx_opis.Text = baza.getOpisy(id);
                    lbl_def.Content = baza.getDefinicja(id);
                    btn_liczba.Content = id+1;
                }
                catch {  }
            }
        }

        private void Btn_nowy_Click(object sender, RoutedEventArgs e)
        {
            baza = new Slowa();
            Czyszczenie();
            SetWorkingButtons();
        }

        private void Button_show_Click(object sender, RoutedEventArgs e)
        {
            if(show == true)
            {
                tbx_opis.Text = "";
                btn_show.Content = "Pokaż";
                show = false;
            }
            else if (show == false)
            {
                tbx_opis.Text = baza.getOpisy(id);
                btn_show.Content = "Ukryj";
                show = true;
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

        private void cbx_ukrywaj_Checked(object sender, RoutedEventArgs e)
        {
            ukrywaj = true;
        }

        private void cbx_ukrywaj_Unchecked(object sender, RoutedEventArgs e)
        {
            ukrywaj = false;
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Program wykonany przez studenta Politechniki Śląskiej Tomasza Bielas.\n" +
                "Program został wykonany wyłącznie w celach edukacyjnych!\n\n\n" +
                "Klawiszologia:\n" +
                "\tEkran edycji (aby dodać pozycję należy wypełnić obydwa pola):\n" +
                "\t\tEnter - dodawanie (w przypadku gdy focus jest ustawiony w polu Definicja)\n" +
                "\t\tCtrl + Enter - dodawanie (w przypadku gdy focus jest ustawiony w polu Opis)\n" +
                "\tEkran zapisu lub wczytywania pliku:\n" +
                "\t\tEnter - wczytaj / zapisz\n" +
                "\t\tEscape - Anuluj\n" +
                "\tGłówny ekran programu:\n" +
                "\t\tN - losuj\n" +
                "\t\tM - ukryj / pokaż\n" +
                "\t\t< - poprzedni\n" +
                "\t\t> - następny\n" +
                "\t\t/ - Przejdź na początek / koniec\n");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N && mode == "test")                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                Btn_losuj_Click(sender, e);
            }
            if (e.Key == Key.M)                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                Button_show_Click(sender, e);
            }
            if (e.Key == Key.OemComma && mode == "nauka")                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                Btn_poprzedni_Click(sender, e);
            }
            if (e.Key == Key.OemPeriod && mode == "nauka")                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                Btn_nastepny_Click(sender, e);
            }
            if (e.Key == Key.OemQuestion && mode == "nauka")                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                btn_liczba_Click(sender, e);
            }
            //MessageBox.Show(e.Key.ToString());
        }

        private void OdsiwerzUkrywanie()
        {
            if (ukrywaj == true)
            {
                btn_show.Content = "Pokaż";
                show = false;
            }
            else
            {
                btn_show.Content = "Ukryj";
                show = true;
            }
        }
    }
}
