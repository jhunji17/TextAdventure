using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRunner : MonoBehaviour
{

    public float movespeed;
    public float maxspeed;
    public float jumpforce;
    bool canJump;

    int FloorLayer;
    public RunManager rm;

    Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Awake()
    {
        FloorLayer = LayerMask.NameToLayer("Floor");
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        float MoveHor = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(MoveHor * movespeed, 0);
        movement = movement * Time.deltaTime;

        if (rm.moveCheck())
        {
            playerRB.AddForce(movement);
            if (playerRB.velocity.x > maxspeed)
            {
                playerRB.velocity = new Vector2(maxspeed, playerRB.velocity.y);
            }
            if (playerRB.velocity.x < -maxspeed)
            {
                playerRB.velocity = new Vector2(-maxspeed, playerRB.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.Space) & canJump)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                playerRB.AddForce(new Vector2(0, jumpforce));
                canJump = false;
            }
        }
    }

    bool isFloor(GameObject obj)
    {
        return obj.layer == FloorLayer;
    }

    void OnCollisionEnter2d(Collision2D col)
    {
        if (isFloor(col.gameObject))
        {
            canJump = true;
        }
    }


}

