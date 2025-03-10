using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class ObjectInteractionScript : MonoBehaviour
{
    GameObject targetObject;
    
    public Transform holdPoint;
    public static bool boxInHand = false;

    void OnTriggerEnter(Collider other) // to detect objects with a box collider set under Camera object
    {
        if (other.CompareTag("Player"))
        {
            return; // Exit the method without further processing to ignore player character from object targeting
        }

        if(other.gameObject.CompareTag("Object"))// debugging purposes
        {
            targetObject = other.gameObject;
        }

        if(other.gameObject.CompareTag("Box")) // to detect box object
        {
            targetObject = other.gameObject;
        }
        else
        {
            targetObject = null;
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
                        Debug.Log("Box rotation:"+targetObject.transform.eulerAngles.y);//debug
                        boxInHand = true;
                        HoldObject();
                    }
                }
                if(boxInHand)  //box rotate
                {

                    if(Input.GetKey(KeyCode.A))
                    {
                        RotateObject(Vector3.down);
                    }
                    else if(Input.GetKey(KeyCode.D))
                    {
                        RotateObject(Vector3.up);
                    }

                    
                }
                
            }

            else if(Input.GetMouseButtonUp(0))
            {
                if(targetObject.tag == "Box")//to drop boxes
                {
                    if(boxInHand)
                    {
                        boxInHand = false;
                        DropObject();
                        targetObject = null;
                    }   
                }
            }
            
            
        }
    }

    void HoldObject()//picking up box
    {
        targetObject.GetComponent<Rigidbody>().isKinematic = true;
        targetObject.transform.position = holdPoint.position;
        targetObject.transform.parent = holdPoint;
    }

    void DropObject()//dropping box
    {
        targetObject.GetComponent<Rigidbody>().isKinematic = false;
        targetObject.transform.parent = null;
    }

    void RotateObject(Vector3 direction)//box rotation
    {
        if(targetObject!=null)
        {
            targetObject.transform.Rotate(direction * 100f * Time.deltaTime);
        }
    }

    

}
