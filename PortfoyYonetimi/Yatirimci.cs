using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimi
{
    public class Yatirimci
    {
        private string adSoyad;
        private string hesapNo;
        private double bakiye;

        public List<Hisse> portfoy;

        public Yatirimci(string adSoyad, string hesapNo, double bakiye)
        {
            this.adSoyad = adSoyad;
            this.hesapNo = hesapNo;
            this.bakiye = bakiye;
            this.portfoy = new List<Hisse>();
        }

        public string GetAdSoyad() { return adSoyad; }
        public string GetHesapNo() { return hesapNo; }
        public double GetBakiye() { return bakiye; }

        public void BakiyeGuncelle(double miktar) { this.bakiye += miktar; }

        public void HisseEkle(Hisse yeniHisse)
        {
            this.portfoy.Add(yeniHisse);
        }
    }
}