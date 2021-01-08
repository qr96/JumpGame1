using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorNext : MonoBehaviour
{
    public bool Cleared;

    // Start is called before the first frame update
    void Start()
    {
        Cleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Cleared == true)
        {
            SceneManager.LoadScene("Map2");
        }
    }
    
}
