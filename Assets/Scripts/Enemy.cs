using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 moveDirection;
    Vector3[] directions;
    // Start is called before the first frame update
    void Start()
    {
        directions = new Vector3[] { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
        RandomDirection(directions);
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator Move()
    {
        //enemy movement
        yield return new WaitForSeconds(1);
        CheckBoundry();
        transform.Translate(moveDirection);
        StartCoroutine(Move());
    }

    private void CheckBoundry()
    {
        //enemy restrictions
        Ray rightRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.right);
        Ray leftRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.left);
        Ray upRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.up);
        Ray downRay = new Ray(transform.position - new Vector3(0, 0, -0.5f), Vector3.down);

        if (!Physics.Raycast(rightRay, 1))
        {
            Vector3[] moveableDirections = new Vector3[] { Vector3.left, Vector3.up, Vector3.down }; 
            RandomDirection(moveableDirections);
        }
        if (!Physics.Raycast(leftRay, 1))
        {
            Vector3[] moveableDirections = new Vector3[] { Vector3.right, Vector3.up, Vector3.down };
            RandomDirection(moveableDirections);
        }
        if (!Physics.Raycast(upRay, 1))
        {
            Vector3[] moveableDirections = new Vector3[] { Vector3.left, Vector3.right, Vector3.down };
            RandomDirection(moveableDirections);
        }
        if (!Physics.Raycast(downRay, 1))
        {
            Vector3[] moveableDirections = new Vector3[] { Vector3.left, Vector3.up, Vector3.right };
            RandomDirection(moveableDirections);
        }
    }

    void RandomDirection(Vector3[] moveableDirections)
    {
        int randomIndex = Random.Range(0, moveableDirections.Length);
        moveDirection = moveableDirections[randomIndex];

    }

    private void OnCollisionEnter(Collision collision)
    {
        //move away from filled cube
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            RandomDirection(directions);
        }
    }
}
