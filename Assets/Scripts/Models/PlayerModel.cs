using UnityEngine;

namespace Models
{
    public class PlayerModel
    {
        public Color Color { get; }
    
        public int Health { get; set; }
        public int CountOfCoins { get; set; }
        public string PlayerName { get; set; }

        public PlayerModel(Color color, int health, int countOfCoins, string playerName)
        {
            Color = color;
            Health = health;
            CountOfCoins = countOfCoins;
            PlayerName = playerName;
        }
    }
}