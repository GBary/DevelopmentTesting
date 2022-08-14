using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isPressingRight = Input.GetKey(KeyCode.RightArrow);
        bool isPressingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isJumping = Input.GetKeyDown(KeyCode.UpArrow);
        bool isShooting = Input.GetKeyDown(KeyCode.Space);

        if(isPressingRight){
            //Move to right
            Vector3 currentPosition = this.gameObject.transform.position;
            Vector3 newPosition = currentPosition + Vector3.right * speed;
            this.gameObject.transform.position = newPosition;
            animator.SetFloat("Movement",3);
        }
        else if(isPressingLeft){
            //Move to left
            Vector3 currentPosition = this.gameObject.transform.position;
            Vector3 newPosition = currentPosition + Vector3.left * speed;
            this.gameObject.transform.position = newPosition;
            animator.SetFloat("Movement",1);
        }else{
            animator.SetFloat("Movement",2);
        }

        if (isJumping){
            Rigidbody2D thisRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

            Vector3 currentVelocity = thisRigidbody.velocity;
            Vector3 newVelocity = currentVelocity + Vector3.up * jumpSpeed;
            thisRigidbody.velocity = newVelocity;
        }

        if(isShooting){
            Shoot();
        }
    }

    void Shoot(){

    }
}
