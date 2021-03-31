using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float _levelTime = 10f;
    LevelController _levelController;
    AttackerSpawner _attackerSpawner;
    bool triggeredLevelFinished = false;

    private void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime;

        bool _timerFinished = (Time.timeSinceLevelLoad >= _levelTime);
        if (_timerFinished)
        {
            _levelController.TimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
