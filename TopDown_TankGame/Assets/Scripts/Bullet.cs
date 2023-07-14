using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public float speed = 10;
    //public int damage = 5;
    //public float maxDistance = 10;

    public BulletData bulletData;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * this.bulletData.speed;
    }

    private void update()
    {
        conquaredDistance = Vector2.Distance(transform.position,
            startPosition);
        if(conquaredDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }

    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collidered" + collision.name);

        var damagable = collision.GetComponent<Damagable>();
        if(damagable != null)
        {
            damagable.Hit(bulletData.damage);

        }
        
        DisableObject();

    }
}
