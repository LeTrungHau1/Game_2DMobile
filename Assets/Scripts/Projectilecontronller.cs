using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectilecontronller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.localPosition.z > 0)//cho viên đạn bắn bên trái bên phải
        {
            rb.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else rb.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
    }

    //viên đạn dừng lại
    public void removeForce()
    {
        rb.velocity = new Vector2(0, 0);
    }

}
