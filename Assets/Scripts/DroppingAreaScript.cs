using UnityEngine;
using UnityEngine.TextCore;

public class DroppingAreaScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isInDroppingArea = false;
    public bool isInCorrectAngle = false;
    public GameObject BoxInDroppingArea;
    float rotationY;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dropped Box"))
        {
            return;
        }
        else if(other.CompareTag("Box"))
        {
            isInDroppingArea = true;
            BoxInDroppingArea = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Box") && BoxInDroppingArea == other.gameObject)
        {
            isInDroppingArea = false;
            isInCorrectAngle = false;
            BoxInDroppingArea = null;
        }
    }
    void Update()
    {
        
        if(isInDroppingArea)
        {
            if(isInDroppingArea && BoxInDroppingArea != null)
            {
                ObjectColorChange objectColorChange = BoxInDroppingArea.GetComponent<ObjectColorChange>();
                Transform angle = BoxInDroppingArea.GetComponent<Transform>();
                rotationY = angle.transform.eulerAngles.y;
                
                if(ObjectInteractionScript.boxInHand == BoxInDroppingArea)
                {
                    if(rotationY>360f)rotationY-=360f;

                    if(rotationY >= 80f && rotationY <= 100f || rotationY >= 260f && rotationY <= 280f)
                    {   
                        objectColorChange.correctColor();
                        isInCorrectAngle = true;
                    }
                    else
                    {
                        isInCorrectAngle = false;
                        objectColorChange.incorrectColor();
                    }
                }

                else 
                {
                    if(isInCorrectAngle)
                    {
                        //Debug.Log("Box name:" + BoxInDroppingArea.name);
                        objectColorChange.resetColor();
                        BoxInDroppingArea.tag = "Dropped Box";
                        objectColorChange.enabled = false;
                    }
                    else
                    {
                        objectColorChange.incorrectColor();
                    }
                    
                }
            }
           
        }
        else{
            return;
        }

    }
    
}
