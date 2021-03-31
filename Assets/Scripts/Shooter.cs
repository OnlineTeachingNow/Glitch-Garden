using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject _projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    [SerializeField] GameObject _projectile;
    [SerializeField] GameObject _gun;
    AttackerSpawner _myLaneSpawner;
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        CreateProjectileParent();
        SetLaneSpawner();
    }

    private void CreateProjectileParent()
    {
        _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!_projectileParent)
        {
            _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(IsAttackerInLane())
        {
            _animator.SetBool("IsAttacking", true);
        }
        else
        {
            _animator.SetBool("IsAttacking", false);
        }
       
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] _spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner _spawner in _spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(_spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                _myLaneSpawner = _spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (_myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ShootProjectile()
    {
        InstantiateProjectile();
        return;
    }

    private void InstantiateProjectile()
    {
        GameObject _newProjectile = Instantiate(_projectile, _gun.transform.position, Quaternion.identity);
        _newProjectile.transform.parent = _projectileParent.transform;
    }
}
