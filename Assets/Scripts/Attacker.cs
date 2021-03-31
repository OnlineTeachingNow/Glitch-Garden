using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float _currentSpeed = 1f; //Speed is set in the animation with SetMovementSpeed method
    GameObject _currentTarget;
    Animator _animator;
    LevelController _levelController;
   
    void Start()
    {
        _animator = GetComponent<Animator>();
        _levelController = FindObjectOfType<LevelController>();
        if (_levelController != null)
        {
            _levelController.AddToNumAttacker();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float _speed)
    {
        _currentSpeed = _speed;
    }

    public void Attack(GameObject target)
    {
        _animator.SetBool("isAttacking", true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget(float _damage)
    {
        if (!_currentTarget)
        {
            return;
        }
        Health _targetHealth = _currentTarget.GetComponent<Health>();
        if (_targetHealth)
        {
            _targetHealth.DamageDealt(_damage);
        }
    }
    public void CheckIfTargetIsDead()
    {
        if (!_currentTarget)
        {
            _animator.SetBool("isAttacking", false);
        }
    }

    private void OnDestroy()
    {
        if (_levelController != null)
        {
            _levelController.DecreaseToNumAttacker();
        }
    }
}
