using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int _defenderCost = 100;

    public void AddStarsFromDefender(int _amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(_amount);
    }

    public int DefenderCost()
    {
        return _defenderCost;
    }
}
