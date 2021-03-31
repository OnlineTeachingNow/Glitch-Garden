using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject _other = other.gameObject;
        if (_other.GetComponent<Gravestone>())
        {
            _animator.SetTrigger("jumpTrigger");
        }    
        else if (_other.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(_other);
        }
    }
}
