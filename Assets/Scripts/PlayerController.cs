using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    bool canMoveRight, canMoveLeft, canMoveForward, canMoveBack;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        canMoveLeft = true;
        canMoveRight = true;
        canMoveForward = true;
        canMoveBack = true;

        CheckIfPlayerCanMove();

        //player movement
        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
            transform.Translate(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
            transform.Translate(Vector3.right);
        if (Input.GetKeyDown(KeyCode.S) && canMoveBack)
            transform.Translate(Vector3.down);
        if (Input.GetKeyDown(KeyCode.W) && canMoveForward)
            transform.Translate(Vector3.up);

    }

    private void CheckIfPlayerCanMove()
    {
        //player restrictions
        Ray rightRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.right);
        Ray leftRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.left);
        Ray upRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.up);
        Ray downRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.down);

        if (!Physics.Raycast(rightRay, 1))
            canMoveRight = false;
        if (!Physics.Raycast(leftRay, 1))
            canMoveLeft = false;
        if (!Physics.Raycast(upRay, 1))
            canMoveForward = false;
        if (!Physics.Raycast(downRay, 1))
            canMoveBack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
            collision.gameObject.tag = "GreenCube";
            gameManager.FillCube();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.ReduceLife();
        }
    }
}
