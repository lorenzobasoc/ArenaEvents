using System;

namespace Arena2
{
    class Warrior : Fighter
    {
        private const int PV_WARRIOR = 100;

        public override event Action<Fighter, Fighter> Died;
        public override event Action<Fighter, Fighter, int> Damaged;
        public override event Action<Fighter> Won;

        public int DamagePercentage { get; set; }

        public Warrior(string name) {
            Name = name;
            Pv = PV_WARRIOR;
            Speed = new Random().Next(60, 100);
            DamagePercentage = (int)(new Random().NextDouble() * new Random().Next(30, 40));
        }

        public override int CalculateDamage(){
            return Pv * DamagePercentage / 100;
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
