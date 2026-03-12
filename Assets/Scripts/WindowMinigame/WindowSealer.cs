using UnityEngine;
using UnityEngine.InputSystem;

public class WindowSealer : MonoBehaviour
{
    public GameObject thing;
    public LineRenderer LR;
    public Camera cam;
    public Vector2 lastPos;
    public bool isDrawing = false;
    public static WindowSealer instance;

    void Start()
    {
        instance = this;
    }
    void Update()
    {     
        Draw();
    }
    public void CreateThing()
    {
        GameObject thingy = Instantiate(thing);
        LR = thingy.GetComponent<LineRenderer>();
        
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        LR.SetPosition(0, mousePos);
        LR.SetPosition(1, mousePos);
    }
    void AddPoint(Vector2 pointPos)
    {
        LR.positionCount++;
        int positionIndex = LR.positionCount - 1;
        LR.SetPosition(positionIndex, pointPos);
    }
    public void Draw()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateThing();
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            isDrawing = true;
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos)
            {
                AddPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            isDrawing = false;
            LR = null;
        }

    }
}
