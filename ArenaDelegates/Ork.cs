using System;

namespace Arena2
{
    class Ork : Fighter
    {
        private const int PV_ORK = 110;

        public override event Action<Fighter, Fighter> Died;
        public override event Action<Fighter, Fighter, int> Damaged;
        public override event Action<Fighter> Won;

        public int Strength { get; set; }

        public Ork(string name) {
            Name = name;
            Pv = PV_ORK;
            Speed = new Random().Next(60, 100);
            Strength = new Random().Next(5, 20);
        }

        public override int CalculateDamage(){
            return Strength;
        }

        public override void Fight(Fighter attacker) {
            var damage = attacker.CalculateDamage(); 
            if (damage < Pv){
                Damaged?.Invoke(this, attacker, damage);
            } else {
                Damaged?.Invoke(this, attacker, damage);
                Died?.Invoke(this, attacker);
            }
        }
        public override void Win(){
            Won?.Invoke(this);
        }
    }
}
