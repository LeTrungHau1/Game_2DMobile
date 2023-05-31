using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    public float damage;
    float damerate = 0.5f;
    public float pushbackforce;
    float nextdamage;
    // Start is called before the first frame update
    void Start()
    {
        nextdamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D orther)
    {
        if (orther.gameObject.tag == "Player" && nextdamage < Time.time) 
        {
            playerhealth theplayerhealth = orther.gameObject.GetComponent<playerhealth>();
            theplayerhealth.adddamage(damage);
            nextdamage=damerate+Time.time;
            pushBack(orther.transform);
        }
    }
    void pushBack(Transform pushobject)
    {
        Vector2 pushDriretion = new Vector2(0, (pushobject.position.y - transform.position.y)).normalized;
        pushDriretion *= pushbackforce;
        Rigidbody2D pushrb = pushobject.gameObject.GetComponent<Rigidbody2D>();
        pushrb.velocity=Vector2.zero;
        pushrb.AddForce(pushDriretion, ForceMode2D.Impulse);


    }    
}
