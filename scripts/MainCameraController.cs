using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Transform Player;
    
    public float dist = 3f;
    public float height = 3f;
    public float dampTrace_max = 5f;
    public float dampTrace = 0.1f;
    //public float rotSpeed = 5f;

    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (dampTrace < dampTrace_max) dampTrace += 0.005f;

        transform.position = Vector3.Lerp(transform.position
            , Player.position - (Player.forward * dist) + (Vector3.up * height)
            , dampTrace * Time.deltaTime);

        transform.LookAt(Player.position);
        
    }
    
}
