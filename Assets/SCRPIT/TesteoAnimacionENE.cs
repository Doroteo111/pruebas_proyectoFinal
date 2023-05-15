using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteoAnimacionENE : MonoBehaviour
{
    private Animator _animator;
    private int hearts = 2;
    public bool isGameOver;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            _animator.SetBool("isWalking", true);
        }
        if (!Input.GetKey("w"))
        {
            _animator.SetBool("isWalking",false);
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            hearts--;
            Debug.Log("hearts");
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack_1");
    }

    public void MinusLife()
    {
      
        if (hearts <= 0)
        {

            GameOver();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        _animator.SetBool("isGameOver", true);
    }
}
