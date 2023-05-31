using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealth : MonoBehaviour
{ 
    public float maxhealth;
    public float currenthealth;


    //thanh máu cho enemy
    public Slider enemeHBsider;

    //rơi máu khi enemy chết
    public bool drop;
    public GameObject thedrop;


    private bool initialEnabled;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
       
        startTime = Time.time;
        currenthealth = maxhealth;
        enemeHBsider.maxValue = maxhealth;
        enemeHBsider.value = currenthealth;
        // Lấy trạng thái enabled ban đầu của đối tượng
        initialEnabled = gameObject.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void adddamge(float damage)
    {
        enemeHBsider.gameObject.SetActive(true);//khi bị tấn công máu sẻ hiện lên
        currenthealth -= damage;
        enemeHBsider.value=currenthealth;
       
        if (currenthealth <= 0 )
        {
            makedead();

            Invoke("hoi", 5f);//sử dụng hàm sau khoản thời gian

        }
    }
    void hoi()
    {
       
        gameObject.SetActive(true);
        gameObject.SetActive(initialEnabled);//đang sửa
        currenthealth = maxhealth;
        enemeHBsider.value = maxhealth;
        enemeHBsider.gameObject.SetActive(false);//ẩn máu sẻ hiện lên
    }

    void makedead()
    {

        gameObject.SetActive(false);//cho enemy ẩn đi

        //Destroy(gameObject);//xóa enemy


        //chức năng rơi vật phẩm khi enen=my chết
        if (drop ) 
        { 
            Instantiate(thedrop,transform.position,transform.rotation);
        }
    }
   
}
