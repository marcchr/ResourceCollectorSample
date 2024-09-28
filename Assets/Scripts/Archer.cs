using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

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

    void Aim()
    {
        Vector3 direction = goblin.transform.position - transform.position;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
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
