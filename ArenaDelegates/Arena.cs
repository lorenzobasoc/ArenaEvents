using System;
using System.Collections.Generic;
using System.Threading;

namespace Arena2
{
    class Arena
    {
        public List<Fighter> fightersList;
        public Arena(List<Fighter> list) {
            fightersList = list;
        }

        public void StartGame() {
            var currentAttack = fightersList.Count - 1;
            while (true) {
                Thread.Sleep(200);
                Again:
                var randomPosition = new Random().Next(0, fightersList.Count); 
                if (randomPosition == currentAttack) {
                    goto Again;
                }
                var attacker = fightersList[currentAttack];
                var attacked = fightersList[randomPosition];
                attacked.Fight(attacker);
                if (attacked.Pv <= 0){
                    fightersList.Remove(attacked);
                }
                if (currentAttack == 0) {
                    currentAttack = fightersList.Count - 1;
                } else {
                    currentAttack--;
                }
                if (fightersList.Count == 1) {
                    break;
                }
            }
            fightersList[0].Win();
        }
    }
}
