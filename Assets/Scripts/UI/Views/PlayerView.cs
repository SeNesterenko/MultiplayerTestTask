using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;
        [SerializeField] private TMP_Text _currentScore;

        public void Initialize(float health, int score)
        {
            _healthBar.maxValue = health;
            Display(health, score);
        }
    
        public void Display(float health, int score)
        {
            _healthBar.value = health;
            _currentScore.text = score.ToString();
        }
    }
}