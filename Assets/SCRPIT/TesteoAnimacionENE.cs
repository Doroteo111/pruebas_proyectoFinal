using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteoAnimacionENE : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //left botton down
        {
            Attack();
        }
    }

    private void Attack()
    {
        _animator.SetInteger("Attack_type", Random.Range(1, 3));
        _animator.SetTrigger("Attack");
    }
}
