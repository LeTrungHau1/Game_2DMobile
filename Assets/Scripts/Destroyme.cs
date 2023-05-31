using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyme : MonoBehaviour
{
    public float destroytime=3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
