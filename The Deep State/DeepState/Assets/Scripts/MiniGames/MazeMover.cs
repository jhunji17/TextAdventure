using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMover : MonoBehaviour
{
    Rigidbody2D playerRigidbody;

    float xAxis;
    float yAxis;
    private int score;
    private bool Mover;

    [SerializeField]
    private float xInitial;

    [SerializeField]
    private float yInitial;

    [SerializeField]
    private float zInitial;

    [SerializeField]
    GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        setMove(false);
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        if (canMove())
        {
            moveFunction2();
        }
        
    }

    void moveFunction2()
    {
        Vector2 movementVector = new Vector2(xAxis * 4 , yAxis * 4);
        playerRigidbody.MovePosition(playerRigidbody.position + movementVector);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "coin")
        {
            coll.gameObject.SetActive(false);
            score++;
        } 
    }

       

        
    

    public void reset()
    {
        Debug.Log(xInitial); Debug.Log(yInitial); Debug.Log(zInitial);
        Vector3 initialVector = new Vector3(xInitial, yInitial, zInitial);
        playerRigidbody.position = initialVector;
        score = 1;
    }

    public int getScore()
    {
        return score;
    }

    public void setMove(bool move)
    {
        Mover = move;
    }

    public bool canMove()
    {
        return Mover;
    }
}
