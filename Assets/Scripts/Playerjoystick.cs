using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Playerjoystick : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Joystick joystick;
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Vector2 moveDir;

    //bắn bullet
    public GameObject bulletPrefab;//viên đạn
    public Transform firePoint;//vị trí

    //nhac bắn
    public AudioSource aus;//nhạc nền
    public AudioClip shootingsound;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        
    }

    // Update is called once per frame
    void Update()
    {
        //Di chuyển nhân vật theo giá trị đầu vào của joystick
        rb.velocity = moveDir * speed;
        moveDir.x = joystick.Horizontal;
        moveDir.y = joystick.Vertical;
        moveDir.Normalize();

        aniplayerrun();
       xoayhuongplayer();

        //bắn dạn
        shootbullet();



    }
    private void FixedUpdate()
    {
       
    }
    private void Awake()
    {
        
    }
    public void aniplayerrun()
    {
      
        if (moveDir.magnitude > 0.01f)
        {
            anim.SetBool("isrunning", true);
          
        }
        else
        {
            anim.SetBool("isrunning", false);
            
        }


       
    }
    public void xoayhuongplayer()
    {
        //xoay hướng player
        if (moveDir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveDir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void shootbullet()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Nếu người chơi chạm vào màn hình
        {
          
            ShootBullet();  // Bắn viên đạn
            
        }
    }
    void ShootBullet( )
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  // Tạo một viên đạn mới từ prefab tại vị trí bắn
        if (aus && shootingsound)//âm thanh
        {
            aus.PlayOneShot(shootingsound);
        }
    }


}
