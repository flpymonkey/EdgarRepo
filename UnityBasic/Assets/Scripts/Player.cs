using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;

    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform groundCheckTransform = null; // putting [SerializedField] is the same as making this public and exposing it to the inspector object in the ui. otherwise this property wont show in the inspector menu

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // this function should have all key presses because they may be missed in the fixed update
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Called once every physics update
    // unity physics engine updates 100 times every second, regardless of the fps
    // all physics, such as forces should be put here
    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) 
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, 0);
    }

}
