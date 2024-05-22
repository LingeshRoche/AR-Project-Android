using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speedx;
    public float speedy;
    public float speedz;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * speedx * Time.deltaTime, 360 * speedy * Time.deltaTime, 360 * speedz * Time.deltaTime);

    }
}



