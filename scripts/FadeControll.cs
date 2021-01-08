using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControll : MonoBehaviour
{
    public GameObject Player;
    public float duration = 2f;
    public float shakePower = 1f;
    public Animation fadeOut;
    public Animation doorLeft;
    public Animation doorRight;

    Vector3 originPos;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(1f);

        float timer = 0;
        originPos = transform.localPosition;
        doorLeft.Play("DoorOpenLeft");
        doorRight.Play("DoorOpenRight");
        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * shakePower + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;

        yield return new WaitForSeconds(2f);
        fadeOut.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        Player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
        
    }

}
