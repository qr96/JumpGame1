using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : MonoBehaviour
{
    public GameObject GameManager;
    public ParticleSystem fire;
    public ParticleSystem Smoke;
    public new ParticleSystem light;
    bool collied;
    bool CheckFire;

    // Start is called before the first frame update
    void Start()
    {
        collied = false;
        CheckFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && collied == true && CheckFire == false)
        {
            FireOn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collied = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collied = false;
        }
        
    }

    void FireOn()
    {
        Debug.Log("Fired");
        CheckFire = true;
        fire.Play();
        Smoke.Play();
        light.Play();
        GameManager.GetComponent<GameManage>().FireOn();
    }

    
}
