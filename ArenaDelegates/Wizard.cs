using System;

namespace Arena2
{
    class Wizard : Fighter
    {
        private const int PV_WIZARD = 100;
        private const int POWER_WIZARD = 100;

        public override event Action<Fighter, Fighter> Died;
        public override event Action<Fighter, Fighter, int> Damaged;
        public override event Action<Fighter> Won;

        public int MaximunPower { get; }

        public Wizard(string nome) {
            Pv = PV_WIZARD;
            Name = nome;
            MaximunPower = POWER_WIZARD;
            Speed = new Random().Next(60, 100);
        }

        public override int CalculateDamage(){
            return (int)(MaximunPower * new Random().NextDouble()); 
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
