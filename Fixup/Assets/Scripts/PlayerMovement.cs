using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public GameObject bullet;
    public GameObject shootPos;

    public float bulletSpeed;
    public float destroyBulletDelay;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;



    bool isGrounded;
    Vector3 velocity;

    // Update is called once per frame
    void Start()
    {
       
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 shootTrans = shootPos.transform.position;

            var bulletPrefab = Instantiate(bullet);
            bulletPrefab.transform.position = shootTrans;
            bulletPrefab.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            Destroy(bulletPrefab, destroyBulletDelay);
        }
    }
}
