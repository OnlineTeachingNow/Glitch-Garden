using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender _defenderPrefab;
    [SerializeField] bool _isGameOver = false;
    DefenderButton[] buttons;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text. Add some!");
        }
        else
        {
            costText.text = _defenderPrefab.DefenderCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        if (_defenderPrefab == null) { return; }
        if (!_isGameOver)
        {
            DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();
            foreach (DefenderButton button in buttons)
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
            }
            GetComponent<SpriteRenderer>().color = Color.white;
            SetDefender(_defenderPrefab);
        }
        else if (buttons !=null)
        {
            foreach (DefenderButton button in buttons)
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
            }
        }

    }

    public void SetDefender(Defender _defender)
    {
        FindObjectOfType<DefenderSpawner>().SelectedDefender(_defender);
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
