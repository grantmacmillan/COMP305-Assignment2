using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipToHazard : MonoBehaviour
{
    private float timer;

    public float speed;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            //Debug.Log("timer working");
            transform.Rotate(Vector3.back * 180);
            timer = 3f;
        }
    }
}
