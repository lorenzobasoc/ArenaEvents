using System;
using System.Collections.Generic;
using System.Linq;

namespace Arena2
{
    class Program
    {
        static void Main() {
            var list = GenerateFighters().OrderBy(o => o.Speed).ToList();
            var arena = new Arena(list);
            foreach (var f in arena.fightersList){
                f.Damaged += HandleDamage;
                f.Died += HandleDeath;
                f.Won += HandleWon;
            }
            arena.StartGame();
        }

        private static void HandleDamage(Fighter attacked, Fighter attacker, int damage){
            Console.WriteLine($"{attacker.Name} infligge {damage} punti di danno a {attacked.Name}");
            attacked.Pv -= damage;
            if (attacked.Pv < 0){
                attacked.Pv = 0;
            }
            Console.WriteLine($"A {attacked.Name} rimangono {attacked.Pv} pv.");
            Console.WriteLine();
        }

        private static void HandleWon(Fighter f){
            Console.WriteLine("***LA LOTTA è TERMINATA***");
            Console.WriteLine($"Il vincitore dell'arena è {f.Name}");       
        }

        private static void HandleDeath(Fighter attacked, Fighter attacker){
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{attacked.Name} è morto!");
            Console.WriteLine();
            Console.ResetColor();        
        }

        private static List<Fighter> GenerateFighters(){
            return new List<Fighter>{
                new Ork("Gino"),
                new Ork("Paolo"),
                new Warrior("Sanna"),
                new Warrior("Susan"),
                new Wizard("Pirla"),
                new Wizard("Strombolo"),
            };
        } 
    }
}
