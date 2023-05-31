using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class bullethit : MonoBehaviour
{
    public float weapondamage;
    Projectilecontronller mypc;//lấy  Rigidbody2D  2d bên object cha
    //public GameObject bulletexplosion;
    private void Awake()
    {
        mypc = GetComponentInParent<Projectilecontronller>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D orther)//va chạm bên ngoài
    {
        if (orther.gameObject.tag == "Shootable") //kiểm tra va chạm với vật thể có tên shootale
        {
           /* Instantiate(bulletexplosion, transform.position, transform.rotation);*///tạo bản sao hiệu ứng nổ(...,vị trí viên đạn,viên đạn bắn đâu ra thì hiệu ứng bên dó)
            Destroy(gameObject);


            if (orther.gameObject.layer == LayerMask.NameToLayer("enemy"))//kểm tra va chạm với đối tượng (player)
            {
                enemyhealth hurtenemy = orther.gameObject.GetComponent<enemyhealth>();//gọi class enemy để sử dụng chức năng của nó
                hurtenemy.adddamge(weapondamage);
            }
        }


    }
    private void OnTriggerStay2D(Collider2D orther)//va chạm nằm bên trong ở giữa
    {
        if (orther.gameObject.tag == "Shootable") //kiểm tra va chạm với vật thể có tên shootale
        {
            /* Instantiate(bulletexplosion, transform.position, transform.rotation);*///tạo bản sao hiệu ứng nổ(...,vị trí viên đạn,viên đạn bắn đâu ra thì hiệu ứng bên dó)
            Destroy(gameObject);
            if (orther.gameObject.layer == LayerMask.NameToLayer("enemy"))//kểm tra va chạm với đối tượng (player)
            {
                enemyhealth hurtenemy = orther.gameObject.GetComponent<enemyhealth>();//gọi class enemy để sử dụng chức năng của nó
                hurtenemy.adddamge(weapondamage);
            }
        }
    }




}
