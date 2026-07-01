using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimi
{
    public class Hisseler
    {
        public List<Hisse> hisse_katalogu;

        public Hisseler()
        {
            hisse_katalogu = new List<Hisse>();
        }

        public void HisseEkle(Hisse hisse)
        {
            this.hisse_katalogu.Add(hisse);
        }
    }
}