using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fizzyo;

public class Avalanche : MonoBehaviour
{
    float visibleHeight;
    private float pressure;

    void Start()
    {
        pressure = 0;
        visibleHeight = Camera.main.orthographicSize - transform.localScale.y;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y - (visibleHeight + 2 * transform.localScale.y) > -3)
        {
            transform.Translate(Vector2.down * 0.3F * Time.deltaTime);
        }
        //		transform.Translate (0, -0.004F, 0);
     
        if (this.transform.position.y - (visibleHeight + 2 * transform.localScale.y) < 1)
        {

            pressure = FizzyoFramework.Instance.Device.Pressure();
            transform.Translate(Vector2.up * 1.5f * pressure * Time.deltaTime);
            
        }

    }

}
