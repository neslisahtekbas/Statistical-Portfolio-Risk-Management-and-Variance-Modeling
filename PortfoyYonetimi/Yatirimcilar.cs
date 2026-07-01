using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimi
{
    public class Yatirimcilar
    {
        public List<Yatirimci> yatirimci_listesi;

        public Yatirimcilar()
        {
            yatirimci_listesi = new List<Yatirimci>();
        }

        public void YatirimciEkle(Yatirimci yatirimci)
        {
            this.yatirimci_listesi.Add(yatirimci);
        }
    }
}