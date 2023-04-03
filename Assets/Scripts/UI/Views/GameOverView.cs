using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _winnerText;
        [SerializeField] private TMP_Text _countOfCoinsText;

        public void Display(string name, string coins)
        {
            _winnerText.text = "Win " + name;
            _countOfCoinsText.text = "with " + coins + " coins";
        }
    }
}