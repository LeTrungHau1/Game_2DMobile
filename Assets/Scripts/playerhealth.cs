using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    public float currenhealth;
    public float maxHealth;
    //public Slider PlayerHBsider;
    public Slider playerhbsider;


    private bool initialEnabled;
    //public GameObject bloodeffect;
    //Start is called before the first frame update
    void Start()
    {
        currenhealth = maxHealth;
        playerhbsider.maxValue = maxHealth;
        playerhbsider.value = maxHealth;

        // Lấy trạng thái enabled ban đầu của đối tượng
        initialEnabled = gameObject.activeSelf;
    }

    //Update is called once per frame
    void Update()
    {

    }
    public void adddamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }
        currenhealth -= damage;
        playerhbsider.value = currenhealth;
        if (currenhealth <= 0)
        {
            makedead();
            //Invoke("hoiplayer", 5f);//sống lại
        }

    }
    //hồi máu khi ăn trái tim
    public void addhealth(float hbamount)
    {
        currenhealth += hbamount;
        if(currenhealth >maxHealth)
        {
            currenhealth=maxHealth;
        }
        playerhbsider.value=currenhealth;
    }

    void hoiplayer()//người chơi sống dậy sao 5 giây
    {
        gameObject.SetActive(true);
        gameObject.SetActive(initialEnabled);//đang sửa
        currenhealth = maxHealth;
        playerhbsider.value = maxHealth;
    }



    void makedead()
    {
        //Instantiate(bloodeffect, transform.position, transform.rotation);
        gameObject.SetActive(false);//cho người chơi ẩn đi
        //Destroy(gameObject);
        SceneManager.LoadScene("menuplaygame");
    }
}
