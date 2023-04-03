using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ConfigPlayerModel
    {
        public int Health => _health;
        public Color Color => _color;
        public int CountOfCoins => _countOfCoins;

        [SerializeField] private int _health;
        [SerializeField] private Color _color;
        [SerializeField] private int _countOfCoins;
    }
}