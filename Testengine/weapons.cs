using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Testengine
{
    public class weapons
    {
        public int spd;
        public int dmg;
        public weapons(int spd, int dmg)
        {
            this.spd = spd;
            this.dmg = dmg;
        }
    }
    public class Bow: weapons
    {
        public int ammo;
        public Bow(int spd, int dmg, int ammo) : base(spd, dmg)
        {
            this.dmg = dmg;
            this.spd = spd;
            this.ammo = ammo;
        }
    }
    public class Staff: weapons
    {
        public int mana;
        public int magdmg;
        public Staff(int spd, int dmg, int mana) : base(spd, dmg)
        {
            this.spd = spd;
            this.magdmg = dmg;
            this.mana = mana;
        }
    }
}
