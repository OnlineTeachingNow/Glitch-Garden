using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _damage = 50f;
    [SerializeField] float _moveSpeed = 2.0f;
    Health _attackerHealth;
 
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(1, 0, 0) * _moveSpeed * Time.deltaTime);
       // this.transform.Rotate(new Vector3(0, 0, 1) * _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Attacker")
        {
            _attackerHealth = other.GetComponent<Health>();
            if (_attackerHealth != null)
            {
                _attackerHealth.DamageDealt(_damage);
                Destroy(this.gameObject);
            }
        }
    }
}
