using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private Transform barrelTip;

    [SerializeField]
    private GameObject bullet;

    private float move, moveSpeed, rotation, rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        rotateSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxisRaw("Horizontal") * -rotateSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }

    private void FireBullet()
    {
        GameObject newBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 10f;
    }
}
