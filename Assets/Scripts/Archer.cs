using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPosition;
    public Animator _animator;

    public float shootInterval;

    public GameObject goblin;
    public bool onGrass = false;


    private void Start()
    {

    }

    private void Update()
    {
        onGrassCheck();
        shootInterval += Time.deltaTime;


        if (shootInterval > 2 && onGrass == true)
        {
            _animator.SetBool("isShooting", true);
            
            shootInterval = 0;
        }
        else
        {
            _animator.SetBool("isShooting", false);

        }
    }

    void Shoot()
    {
        Instantiate(arrow, arrowPosition.position, Quaternion.identity);
    }
    
    void onGrassCheck()
    {
        if (goblin.transform.position.x < 0)
        {
            onGrass = true;
        }
        else
        {
            onGrass = false;
        }
    }
}
