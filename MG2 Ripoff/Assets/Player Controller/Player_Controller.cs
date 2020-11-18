using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour
{
    private Animator anim;
    private bool playerMoving;
    private bool pMovingHor;
    private bool pMovingVert;
    private bool attacking;
    private float attackTimeCounter;
    private float speed = 0;

    public Vector2 lastMove;
    public float maxSpeed;
    public float acceleration;
    public float attackTime;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("Move X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("Move Y", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("LastMoveY", lastMove.y);
        

        attacking = attack();

        if (pMovingHor == false)
            verticalMovement();

        if (pMovingVert == false)
            horizontalMovement();

        if (pMovingHor == false && pMovingVert == false)
        {
            speed = 0;
            playerMoving = false;
        }
        else
            playerMoving = true;
    }

    bool attack()
    {
        if (Input.GetAxisRaw("Fire1") > 0.5f)
        {
            speed = speed * 0.25f;
            return true;
        }
        if (Input.GetAxisRaw("Fire1") < 0.5f)
        {
            return false;
        }
        return false;
    }

    bool verticalMovement()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (speed < maxSpeed)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * (speed = speed + acceleration) * Time.deltaTime, 0f));
            }
            else
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * maxSpeed * Time.deltaTime, 0f));
            }
            pMovingVert = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        else
            pMovingVert = false;

        return pMovingVert;
    }

    bool horizontalMovement() {

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (speed < maxSpeed)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * (speed = speed + acceleration) * Time.deltaTime, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * maxSpeed * Time.deltaTime, 0, 0));
            }
            pMovingHor = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        else
            pMovingHor = false;

        return pMovingHor;

    }  
}

 