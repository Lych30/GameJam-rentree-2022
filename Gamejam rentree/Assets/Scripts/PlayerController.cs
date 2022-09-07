using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private CharacterController controller;
    private Vector3 dir;
    [SerializeField] private float speed;

    [Header("Position")]
    private int desiredLane = 1; //1: bas milieu, 2: bas droit, 3: haut droit, 4: haut milieu, 5: haut gauche, 6: bas gauche
    public float laneDistance = 4;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        dir.z = speed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 7)
            {
                desiredLane = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == 0)
            {
                desiredLane = 6;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 1)
        {
            targetPosition += Vector3.left * laneDistance;
        }
    }

    void FixedUpdate()
    {
        controller.Move(dir * Time.fixedDeltaTime);
    }
}
