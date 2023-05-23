using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField][Range(0, 100)] private float speed = 10;
        private Vector3 movement;

        private void FixedUpdate()
        {
            //movemtent
            movement = new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            transform.Translate(movement.normalized * Time.deltaTime * speed);

            // movement rotetion
            float movementAngle = Mathf.Atan2(movement.x, movement.z);
            transform.rotation = Quaternion.Euler(new Vector3(0f, movementAngle, 0f));
        }
    }
}
