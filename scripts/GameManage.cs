using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public GameObject DoorCamera;
    public GameObject InnerDoor;

    int FireNum;
    public bool Cleared;
    // Start is called before the first frame update
    void Start()
    {
        FireNum = 0;
        Cleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FireNum==2 && Cleared == false)
        {
            Cleared = true;
            OpenDoor();
        }
    }

    public void FireOn()
    {
        FireNum++;
    }

    void OpenDoor()
    {
        DoorCamera.SetActive(true);
        InnerDoor.GetComponent<DoorNext>().Cleared = true;
    }
}
