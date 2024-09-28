using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject goblin;
    private Rigidbody2D rb;
    public float force;
    private float lifetime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goblin = GameObject.FindGameObjectWithTag("goblin");

        Vector3 direction = goblin.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
    }

    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime > 8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("goblin"))
        {
            Destroy(gameObject);
        }
    }
}
