using UnityEngine;

public class ObjectColorChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material correctPosMaterial;
    public Material incorrectPosMaterial;
    public Material defaultMaterial;
    //bool isInCorrectAngle = false;
    Renderer boxRenderer;
    //BoxCollider boxCollider;
    
    //float rotationY;

    void Start()
    {
        boxRenderer = GetComponent<Renderer>();
        boxRenderer.material = new Material(boxRenderer.sharedMaterial);
        //boxCollider = GetComponent<BoxCollider>();
    }


    // Update is called once per frame
    public void correctColor()
    {
        if(boxRenderer!=null && correctPosMaterial!=null) 
        {
            boxRenderer.material = correctPosMaterial;
        }
    }
    public void incorrectColor()
    {
        if(boxRenderer!=null && incorrectPosMaterial!=null) 
        {
            boxRenderer.material = incorrectPosMaterial;
        }
    }
    public void defaultColor()
    {
        if(boxRenderer!=null && defaultMaterial!=null)
        {
            boxRenderer.material = defaultMaterial;
        }
    }

    public void resetColor()
    {
        if(boxRenderer!=null && defaultMaterial!=null)
        {
            boxRenderer.material = defaultMaterial;
        }
    }
}
