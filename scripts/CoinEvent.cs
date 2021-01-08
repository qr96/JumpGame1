using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEvent : MonoBehaviour
{
    public GameObject star;
    public GameObject desertCoin;
    public AudioClip coinSound;
    public AudioSource SoundManager;
    bool CheckGet;
    // Start is called before the first frame update
    void Start()
    {
        CheckGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CheckGet == false)
        {
            StartCoroutine(StarEffect());
            
        }
    }

    IEnumerator StarEffect()
    {
        CheckGet = true;
        desertCoin.SetActive(false);
        Instantiate(star, transform);
        SoundManager.PlayOneShot(coinSound);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
