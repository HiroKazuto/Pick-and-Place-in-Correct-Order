using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteractionScript : MonoBehaviour
{
    private GameObject targetObject;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Object"))
        {
            targetObject = other.gameObject;
            
        }
        Debug.Log("Triggered by "+ other.gameObject.name);
        Debug.Log("Trigger");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                Destroy(targetObject);
            }
    }
}
