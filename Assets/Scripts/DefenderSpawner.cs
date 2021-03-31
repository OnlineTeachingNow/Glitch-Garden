using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender _defender;
    GameObject _defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";
    int _cost;
    StarDisplay _starDisplay;
    bool _isGameOver = false;

    private void Start()
    {
        CreateDefenderParent();
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void CreateDefenderParent()
    {
        _defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!_defenderParent)
        {
            _defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void SelectedDefender(Defender _defenderToSelect)
    {
        _defender = _defenderToSelect;
    }

    private void OnMouseDown()
    {
        if (!_isGameOver)
        {
            AttemptToPlaceDefenderAt(SnapToGrid(GetSquareClicked()));
        }
    }

    private void AttemptToPlaceDefenderAt(Vector2 _gridPos)
    {
        if (_defender != null)
        {
            _cost = _defender.DefenderCost();
        }
        else
        {
            return;
        }
        //if we have enough stars, we can buy a defender
        if (_starDisplay.HaveEnoughStars(_cost))
        {
            SpawnDefender(_gridPos);
            _starDisplay.BuyDefender(_cost);
        }
    }

    private void SpawnDefender(Vector2 _worldPos)
    {
        if (_defender != null)
        {
            Defender _newDefender = Instantiate(_defender, _worldPos, Quaternion.identity);
            _newDefender.transform.parent = _defenderParent.transform;
        }
    }


    private Vector2 GetSquareClicked()
    {
        Vector2 _clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 _worldPos = Camera.main.ScreenToWorldPoint(_clickPos);
        return _worldPos;
    }
    private Vector2 SnapToGrid(Vector2 _rawWorldPos)
    {
        float newX = Mathf.RoundToInt(_rawWorldPos.x);
        float newY = Mathf.RoundToInt(_rawWorldPos.y);
        return new Vector2(newX, newY);

    }

    public void GameOver()
    {
        _isGameOver = true;
    }    
}
