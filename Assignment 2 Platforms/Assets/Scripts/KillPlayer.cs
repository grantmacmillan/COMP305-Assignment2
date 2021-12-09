using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            SceneManager.LoadScene("SampleScene");
        }
    }
}
