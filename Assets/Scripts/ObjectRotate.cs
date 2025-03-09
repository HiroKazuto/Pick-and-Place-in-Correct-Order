using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Rotate()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0, Space.World);
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 45 * Time.deltaTime, 0, Space.World);
            Debug.Log("E");
        }
    }

    // Update is called once per frame

}
