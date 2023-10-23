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
        public List<string> inventory;
        public Player(int hp, int armr, int lvl, string wpn)
        {
            this.hp = hp;
            this.armr = armr;
            this.lvl = lvl;
            this.wpn = wpn;
            this.money = 0;
            this.spd = 5;
            this.mana = 100;
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
        public void GetWeapon(string wpn)
        {
            switch (wpn)
            {
                case "sword":
                    this.dmg = 20;
                    this.spd = 2;
                    break;
                case "axe":
                    this.dmg = 50;
                    this.spd = 1;
                    break;
                case "bow":
                    this.dmg = 25;
                    this.spd = 1;
                    break;
                case "hand":
                    this.dmg = 10;
                    this.spd = 3;
                    break;
                default:
                    this.dmg = 0;
                    this.spd = 0;
                    break;
            }
        }
    }
}
