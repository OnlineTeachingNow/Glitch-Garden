using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int _numberOfStars = 100;
    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = _numberOfStars.ToString();
    }

    public void AddStars(int _numStarsAdded)
    {
        _numberOfStars += _numStarsAdded;
        UpdateDisplay();
    }

    public void BuyDefender(int _cost)
    {
        if (_cost <= _numberOfStars)
        {
            _numberOfStars -= _cost;
            UpdateDisplay();
        }
    }
    public bool HaveEnoughStars(int _cost)
    {
        return _numberOfStars >= _cost;
    }
}
