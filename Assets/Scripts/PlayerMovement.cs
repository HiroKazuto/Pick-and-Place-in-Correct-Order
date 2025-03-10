using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float horizontal;
    float vertical;
    float turnSmoothVelocity;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }
    void Update()
    {   
            if(!ObjectInteractionScript.boxInHand)//to freeze Horizontal Input when the box is in hand to rotate the box
            {
                horizontal = Input.GetAxisRaw("Horizontal");
            }
            vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if(direction.magnitude >= 0.1f)//math behind playermovement
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f); 
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                characterController.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        
        
        

        
        
    }

   


}
