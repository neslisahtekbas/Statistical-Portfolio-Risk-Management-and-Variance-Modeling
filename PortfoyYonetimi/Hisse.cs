using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimi
{
    public class Hisse
    {
        private string kod;
        private string sektor;
        private double fiyat;
        private double hacim;
        private string piyasaDegeri;

        public Hisse(string kod, string sektor, double fiyat, double hacim, string piyasaDegeri)
        {
            this.kod = kod;
            this.sektor = sektor;
            this.fiyat = fiyat;
            this.hacim = hacim;
            this.piyasaDegeri = piyasaDegeri;
        }

        public string GetKod() { return kod; }
        public string GetSektor() { return sektor; }
        public double GetFiyat() { return fiyat; }
        public double GetHacim() { return hacim; }
        public string GetPiyasaDegeri() { return piyasaDegeri; }

        public void SetFiyat(double yeniFiyat) { this.fiyat = yeniFiyat; }
    }
}