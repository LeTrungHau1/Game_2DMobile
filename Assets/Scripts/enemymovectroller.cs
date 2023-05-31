using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemymovectroller : MonoBehaviour
{
    public float enemyspeed;
    Rigidbody2D enemyrb;
    Animator enemyanim;
  

    //khai báo bến enemy lật được
    public GameObject ennemygraphic; //chứa enemy
    bool facingright = true; //quay mặt sang phải mặc định nó
    float facingtime = 5f;  //5 giây lật 1 lần
    float nextflip = 0f;   //lượt lật tiếp theo của enemy
    bool canflip = true;  //player chưa va chạm thì enemy lật được


   


    // Start is called before the first frame update

    void Awake()
    {
        enemyrb = GetComponent<Rigidbody2D>();
        enemyanim= GetComponentInChildren<Animator>(); //lấy anemi từ biến con
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextflip)//thời gian hiện tại lớn hơn tg+facingtime
        {
            nextflip = Time.time+ facingtime;
            flip();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (facingright && other.transform.position.x < transform.position.x)
            {

                flip();
            }
            else if (!facingright && other.transform.position.x > transform.position.x)
            {
                flip();
            }

            canflip = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {


            if (!facingright)
            {
     
                enemyrb.AddForce(new Vector2(-1, 0) * enemyspeed);
              
            }
            else
            {
                enemyrb.AddForce(new Vector2(1, 0) * enemyspeed);
            }
            if (enemyanim != null)
            {
                enemyanim.SetBool("run", true);
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canflip = true;
        }
        enemyrb.velocity = new Vector2(0, 0);
        if (enemyanim != null)
        {
            enemyanim.SetBool("run", false);
        }

    }


    void flip()
    {
        if (enemyanim != null)
        {
            if (!canflip)  //canflip = false
            {
                return;
            }
            facingright = !facingright;
            Vector3 thescale = ennemygraphic.transform.localScale;
            thescale.x *= -1;
            ennemygraphic.transform.localScale = thescale;
        }
    }
   
    
}
