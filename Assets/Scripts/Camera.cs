using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Vector3 player;
    GameObject slime;
    void Start()
    {
        slime = GameObject.Find("slime");
        
    }

    // Update is called once per frame
    void Update()
    {
        player = slime.GetComponent<Rigidbody2D>().transform.position;
        transform.position = new Vector3 (player.x, player.y, transform.position.z);
    }
}
