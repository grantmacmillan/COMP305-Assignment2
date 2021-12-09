using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    public Transform rotationPoint;
    public Rigidbody2D rb;
    public float speed;
    public float radius;
    private float posX, posY;

    private bool freeze = false;


    private float angle = 0;

    // Update is called once per frame
    void Update()
    {
        if (freeze == false)
        {
            posX = rotationPoint.position.x + Mathf.Cos(angle) * radius;
            posY = rotationPoint.position.y + Mathf.Sin(angle) * radius;

            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * speed;
        }

        

        //Debug.Log("X: "+transform.position.x +", Y: "+transform.localPosition.y);

        if(transform.localPosition.y >= 4.999 || transform.localPosition.y <= -4.999 || transform.localPosition.x >= 4.999 || transform.localPosition.x <= -4.999)
        {
            StartCoroutine(FreezePlatform());
            
        }

        

        if (angle >= 360) //resets angle
        {
            angle = 0;
        }

        
    }

    IEnumerator FreezePlatform()
    {
        freeze = true;
        yield return new WaitForSeconds(1f);
        freeze = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
