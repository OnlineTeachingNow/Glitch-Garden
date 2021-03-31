using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _health = 100f;
    [SerializeField] GameObject _deathVX;
    public void DamageDealt(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            TriggerDeathVFX();
            ExecuteDeath();
        }
    }

    private void ExecuteDeath()
    {
        Destroy(this.gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!_deathVX) { return; }
        GameObject _deathVFXObject = Instantiate(_deathVX, this.transform.position, this.transform.rotation);
        Destroy(_deathVFXObject.gameObject, 1f);
    }
}
