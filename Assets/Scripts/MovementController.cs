using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField][Range(0, 100)] private float speed = 10;
        private Vector3 movement;
        [SerializeField] private FixedJoystick joystick;

        private void FixedUpdate()
        {
            //movement
            
            movement = new(joystick.Horizontal, 0f, joystick.Vertical);
            transform.Translate(movement.normalized * Time.deltaTime * speed);

            // movement rotetion
            //float movementAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(new Vector3(0f, movementAngle, 0f));
        }
    }
}
