using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_do_nauki
{
    [Serializable]
    public class Slowa
    {
        public List<string> definicje = new List<string>();
        public List<string> opisy = new List<string>();

        public string getDefinicja(int x)
        {
            return definicje[x];
        }

        public string getOpisy(int x)
        {
            return opisy[x];
        }

        public List<string> getDefinicja()
        {
            return definicje;
        }

        public List<string> getOpisy()
        {
            return opisy;
        }

        public void setDefinicja(string x)
        {
            definicje.Add(x);
        }

        public void setOpis(string x)
        {
            opisy.Add(x);
        }

        public void setDefinicja(List<string> x)
        {
            definicje = x;
        }

        public void setOpis(List<string> x)
        {
            opisy = x;
        }

        public int getRozmiar()
        {
            return definicje.Count;
        }
    }
}
