using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] _attackers;
    bool _spawn = true;
    [SerializeField] float _minSpawnDelay = 1.0f;
    [SerializeField] float _maxSpawnDelay = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFrequency());
    }

    private IEnumerator SpawnFrequency()
    {
        while(_spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            SpawnAttacker();
        }

    }

    private void SpawnAttacker()
    {
        int _attackerIndex = Random.Range(0, _attackers.Length);
        Spawn(_attackerIndex);
    }

    private void Spawn(int _attackerIndex)
    {
        Attacker _newAttacker = Instantiate(_attackers[_attackerIndex], this.transform.position, Quaternion.identity);
        _newAttacker.transform.parent = this.transform;
    }

    public void StopSpawning()
    {
        _spawn = false;
    }
}
