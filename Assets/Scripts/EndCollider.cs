using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCollider : MonoBehaviour
{
    [SerializeField] Text _livesText;
    float _baseLives = 5;
    float _numberOfLives;
    [SerializeField] int _damage = 1;
    LevelController _levelController;
    DefenderButton _defenderButton;
    DefenderSpawner _defenderSpawner;
    // Start is called before the first frame update
    void Start()
    {
        _numberOfLives = _baseLives - PlayerPrefsController.GetDifficultyLevel();
        _levelController = FindObjectOfType<LevelController>();
        _defenderButton = FindObjectOfType<DefenderButton>();
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
        Debug.Log("Difficulty Level is " + PlayerPrefsController.GetDifficultyLevel());
        Debug.Log("Number of Lives " + _numberOfLives);
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        _livesText.text = _numberOfLives.ToString();
        if (_numberOfLives <= 0)
        {
            _defenderSpawner.GameOver();
            _defenderButton.GameOver();
            _levelController.PlayerLoses();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attacker")
        {
            _numberOfLives -= _damage;
            Destroy(other.gameObject);
            UpdateDisplay();
        }
    }
}
