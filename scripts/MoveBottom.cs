using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBottom : MonoBehaviour
{
    public GameObject Player;
    public float moveDis = 10f;
    public float moveSpeed = 2f;
    float moving;
    int dir;
    bool collied;
    // Start is called before the first frame update
    void Start()
    {
        moving = 0f;
        dir = 1;
        collied = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(moving < 0)
        {
            dir = 1;
        }
        else if(moving > moveDis)
        {
            dir = -1;
        }
        
        moving += dir;
        transform.Translate(new Vector3(dir, 0, 0) * moveSpeed * Time.deltaTime);
        if (collied == true) Player.transform.Translate(transform.TransformVector(new Vector3(dir, 0, 0)) * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collied");
        collied = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("not");
        collied = false;
    }
}
