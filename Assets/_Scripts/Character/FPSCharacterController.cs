using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float sprintspeed = 10f;

    private string Z_Movement = "Vertical";
    private string X_Movement = "Horizontal";

    private void Update()
    {
        Move();
        Sprint();
    }

    private void Move()
    {
        float translation = Input.GetAxis(Z_Movement) * speed;
        float strafing = Input.GetAxis(X_Movement) * speed;
        translation *= Time.deltaTime;
        strafing *= Time.deltaTime;

        transform.Translate(strafing, 0, translation);
    }

    private void Sprint()
    {
        if (Input.GetButton("Sprint"))
        {
            speed = sprintspeed;
        }
        else
        {
            speed = 5f;
        }
    }
}
