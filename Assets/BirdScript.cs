using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flapStrength;
    public LogicScript logic;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = FindObjectOfType<LogicScript>();
        Hop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return;  }

        Quaternion look = Quaternion.Slerp(Quaternion.AngleAxis(-45, Vector3.forward), Quaternion.AngleAxis(45, Vector3.forward), rigidBody.velocity.y);
        rigidBody.SetRotation(look);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hop();
        }
    }

    private void Hop()
    {
        rigidBody.velocity = Vector2.up * flapStrength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        isAlive = false;
    }
}
