using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int _numberOfAttackers;
    [SerializeField] GameObject _winLabel;
    [SerializeField] GameObject _loseLabel;
    bool _timerFinished = false;
    [SerializeField] float _nextLevelDelay = 2f;
    [SerializeField] float _gameOverDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _loseLabel.SetActive(false);
        _winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToNumAttacker()
    {
        _numberOfAttackers++;
    }

    public void DecreaseToNumAttacker()
    {
        _numberOfAttackers--;
        if (_timerFinished && _numberOfAttackers <= 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        _winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(_nextLevelDelay);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void PlayerLoses()
    {
        StartCoroutine(HandleLoseCondition());
    }
    public IEnumerator HandleLoseCondition()
    {
        yield return new WaitForSeconds(_gameOverDelay);
        Time.timeScale = 0;
        _loseLabel.SetActive(true);
    }
    public void TimerFinished()
    {
        _timerFinished = true;
        StopSpawning();
    }

    private void StopSpawning()
    {
        AttackerSpawner[] _spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner _spawner in _spawnerArray)
        {
            _spawner.StopSpawning();
        }
    }
}
