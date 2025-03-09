using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteractionScript : MonoBehaviour
{
    GameObject targetObject;
    public Transform heldObject;
    public Transform holdPoint;
    public static bool boxInHand = false;
    void OnTriggerEnter(Collider other) // to detect objects with a box collider set under Camera object
    {
        if (other.CompareTag("Player"))
        {
            return; // Exit the method without further processing to ignore player character from object targeting
        }

        if(other.gameObject.CompareTag("Object"))
        {
            targetObject = other.gameObject;
            
        }

        if(other.gameObject.CompareTag("Box"))
        {
            targetObject = other.gameObject;
        }
        Debug.Log("Triggered by "+ other.gameObject.name);
        Debug.Log("Trigger");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    void Update()
    {
        if(targetObject!=null)
        {
            
            if(Input.GetMouseButton(0))
            {
                if(targetObject.tag == "Box")//to pick up boxes
                {
                    if(!boxInHand)
                    {
                        boxInHand = true;
                        HoldObject();
                           
                    }
                }
                if(boxInHand)
                {
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        Debug.Log("Q");
                        RotateObject(Vector3.up);
                    } 
                }
                
            }

            else if(Input.GetMouseButtonUp(0))
            {
                if(targetObject.tag == "Box")//to pick up boxes
                {
                    if(boxInHand)
                    {
                        boxInHand = false;
                        DropObject();
                    }
                }
            }
            

            
        
        }
    }

    void HoldObject()
    {
        targetObject.GetComponent<Rigidbody>().isKinematic = true;
        targetObject.transform.position = holdPoint.position;
        targetObject.transform.parent = holdPoint;

        
    }

    void DropObject()
    {
        targetObject.GetComponent<Rigidbody>().isKinematic = false;
        targetObject.transform.parent = null;
    }

    void RotateObject(Vector3 direction)
    {
        if(targetObject!=null)
        {
            targetObject.transform.Rotate(direction * 100f * Time.deltaTime);
        }
    }

    

}
