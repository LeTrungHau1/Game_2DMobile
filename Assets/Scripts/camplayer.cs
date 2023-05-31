using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class camplayer : MonoBehaviour
{
    public Transform player;

    //public float speedcam = 10.0f;// Tốc độ di chuyển camera
    //public float rotationSpeed = 5.0f;
    //public Vector3 offset;

    public float minx, maxx;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.position;

        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        movecamplayer();
    }
    private void LateUpdate()
    {



        //if (player == true)//nếu hb người chơi còn thì cho camera theo người chơi
        //{

        //    // Di chuyển camera theo người chơi
        //    float vertical = Input.GetAxis("Vertical");
        //    float horizontalMove = Input.GetAxis("Horizontal");

        //    // Tính vị trí mới của camera
        //    Vector3 desiredPosition = player.position + offset;
        //    Vector3 direction = new Vector3(horizontalMove, 0, vertical);
        //    Vector3 moveVector = Quaternion.Euler(0, player.eulerAngles.y, 0) * direction;
        //    desiredPosition += moveVector * speedcam * Time.deltaTime;

        //    // Cập nhật vị trí camera
        //    transform.position = desiredPosition;

        //    transform.LookAt(player);
        //}
    }

    void movecamplayer()
    {
         if(player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            if(temp.x < minx)
            {
                temp.x = minx;

            }
            if(temp.x > maxx)
            {
                temp.x = maxx;
            }
            transform.position = temp;
        }   
    }

}
