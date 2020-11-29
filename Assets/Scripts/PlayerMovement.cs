using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject panel;
    public Vector2 lastMove;
    public float attackingTime;
    public string startPoint;

    private Animator anim;
    private Rigidbody2D myBody;
    private bool playerMoving;
    private static bool playerrExist;
    private bool attacking;
    private float attackTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();

        if (!playerrExist)
        {
            playerrExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        playerMoving = false;

        if (!attacking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {

                myBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myBody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {

                myBody.velocity = new Vector2(myBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myBody.velocity = new Vector2(0f, myBody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, 0f);
            }
        }

        if (attackTimeCounter > 0)
            attackTimeCounter -= Time.deltaTime;

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("PlayerAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            attackTimeCounter = attackingTime;
            attacking = true;
            myBody.velocity = Vector3.zero;
            anim.SetBool("PlayerAttacking", true);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickable")
        {
            Score.instance.ScoreUp();
            PlayerHPmanager.instance.playerCurrentHealth += 3.5f;
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Pickable2")
        {
            Score.instance.ScoreUp();
            PlayerHPmanager.instance.playerCurrentHealth += 6.5f;
            collision.gameObject.SetActive(false);
        }


        if (collision.tag == "Pickable3")
        {
            Score.instance.ScoreUp();
            PlayerHPmanager.instance.playerCurrentHealth += 9f;
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Finish")
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
