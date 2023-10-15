using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rb;
    private Vector2 mousePos, targetPos;
    private Vector3 worldPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
    }


    void Update()
    {
        mousePos = Input.mousePosition;

        ////check if out of bounds
        //if (mousePos.x < 0 || mousePos.x > Screen.width ||
        //    mousePos.y < 0 || mousePos.y > Screen.height)
        //{
        //    return;
        //}

        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        //transform.position = worldPos;
        targetPos = Vector2.MoveTowards(transform.position, worldPos, speed * Time.deltaTime);

        if (targetPos.x > -10)
        {
            rb.MovePosition(targetPos);
        }
    }
}