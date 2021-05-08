using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp17
{
    class Class1
    {
        private const string FILE_NAME = "NowyPlik.txt";
        FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew);
        string nazwa;
        string kolor;
        int x;
        int y;
        string s;

        public Class1(string nazwa, string kolor, int x, int y)
        {
            this.nazwa = nazwa;
            this.kolor = kolor;
            this.x = x;
            this.y = y;
        }
        public string zapisPliku()
        {
            string s = nazwa + " " + kolor + " " + Convert.ToString(x) + " " + Convert.ToString(y);
            return s;
        }
    }
}
