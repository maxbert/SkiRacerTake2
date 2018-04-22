using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : MonoBehaviour
{
    float visibleHeight;


    void Start()
    {
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
        print(this.transform.position.y - (visibleHeight + 2 * transform.localScale.y));
        if (Input.GetKey("up") && this.transform.position.y - (visibleHeight + 2 * transform.localScale.y) < 1)
        {
            if (transform.localScale.y <= 0)
            {
                transform.Translate(Vector2.up * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * 2 * Time.deltaTime);
            }
        }

    }

}
