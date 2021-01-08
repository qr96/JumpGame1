using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource SoundManager;
    public AudioClip jumpSound;
    public float moveSpeed = 3f;
    public float jumpPower = 6f;
    public float rotSpeed = 5f;

    private Rigidbody rigid;
    public Animator animator;
    public Transform cameraArm;

    Vector3 movement;

    bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal") / 3 * 2;
        float v = Input.GetAxisRaw("Vertical");
        float mouse_y = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * rotSpeed);
        cameraArm.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * rotSpeed);

        if (h == 0 && v == 0)
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            StartCoroutine(JumpSound());
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    IEnumerator JumpSound()
    {
        SoundManager.PlayOneShot(jumpSound);
        yield return new WaitForSeconds(1f);
    }

}
