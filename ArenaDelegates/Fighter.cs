using System;

namespace Arena2
{
    public abstract class Fighter 
    {
        public int Pv;
        public int Speed;
        public string Name;
        public abstract void Fight(Fighter attacker);
        public abstract void Win();
        public abstract int CalculateDamage();

        public abstract event Action<Fighter, Fighter> Died;
        public abstract event Action<Fighter, Fighter, int> Damaged;
        public abstract event Action<Fighter> Won;
    }
}
