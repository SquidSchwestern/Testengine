using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Testengine
{
    public class Player
    {
        public string direction;
        public int hp;
        public int armr;
        public int lvl;
        public string wpn;
        public string secwpn;
        public int count;
        public int wpncd;
        public int dmg;
        public int spd;
        public int money;
        public int mana;
        public int bc;
        public int bcd;
        public Player(int hp, int armr, int lvl, string wpn)
        {
            this.hp = hp;
            this.armr = armr;
            this.lvl = lvl;
            this.wpn = wpn;
            this.money = 0;
            this.spd = 5;
            this.mana = 100;
            this.bc = 0;
            this.bcd = 0;
        }
        public int ReceiveDamage(int dmg)
        {
            hp -= CalculateDamage(dmg,armr);
            if (hp <= 0)
            {
                return 0;
            }
            else
            {
                return hp;
            }    
        }
        public int CalculateDamage(int dmg,int armr)
        {
            if (dmg - armr <= 0)
            {
                return 1;
            }
            else return (dmg - armr);
        }
        
    }
}
