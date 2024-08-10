using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed; //speed of walking, attacks etc
    public float velocity;  //tells us the direction we are moving in. 
                            //here we are not going fir vector 2/3 bec we only want to turn left or right.
                            //this velocity is not about which direction we can move... its about which direction we can turn
                            //hence, looks loke we can"t turn anywhere but left or right.
    public Rigidbody rb;

    public Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    void GetInput(){
        //move to left
        if (Input.GetKey(KeyCode.A)){        // when u start pressing
            SetVelocity(-1);
        }else if (Input.GetKeyUp(KeyCode.A)){               //when you stop pressing 
            SetVelocity(0);

        }

        //move right
        if (Input.GetKey(KeyCode.D)){     
            SetVelocity(1);      // when u start pressing
        }else if (Input.GetKeyUp(KeyCode.D)){ 
            SetVelocity(0);   //when you stop pressing
        }
    }

    void  Move(){
        if(velocity == 0){
            anim.SetInteger("Condition", 0);
            return;
        }else {
            anim.SetInteger("Condition",1);
        }
        rb.MovePosition(transform.position + (Vector3.right*velocity*movementSpeed*Time.deltaTime));
    }

    void SetVelocity(float dir){
        if (dir < 0)    transform.LookAt(transform.position + Vector3.left);
        else if (dir > 0)   transform.LookAt(transform.position + Vector3.right);
        velocity = dir;
    }
}
