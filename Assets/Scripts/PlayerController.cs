using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f; //szybkoœæ naszej postaci
    public float gravity = -10; //przyspieszenie ziemskie 
    Vector3 velocity; //wyliczona prêdkoœæ w ka¿dym kierunku
    CharacterController characterController; //komponent Character Controller

    public Transform groundCheck;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        
    }

    private void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
           out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default:
                    speed = 12;
                    UnityEngine.Debug.Log("Default detected");

                    break;
                case "Slow":
                    speed = 3;
                    UnityEngine.Debug.Log("Low detected");
                    break;
                case "Fast":
                    speed = 20;
                    UnityEngine.Debug.Log("High detected");

                    break;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUps>().Picked();
        }
     
    }
}

