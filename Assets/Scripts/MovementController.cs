using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField][Range(0, 100)] private float speed = 10;
        private Vector3 movement;
        [SerializeField] private int rotationSpeed = 800;
        //[SerializeField] private FixedJoystick joystick;

        private void FixedUpdate()
        {
            //movement
            
            movement = new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            movement.Normalize();
            transform.Translate(movement * Time.deltaTime * speed, Space.World);

            // movement rotetion
            if(movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
