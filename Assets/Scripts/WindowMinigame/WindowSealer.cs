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
        //creates the line renderer and sets the first point to where the mouse is
        GameObject thingy = Instantiate(thing);
        LR = thingy.GetComponent<LineRenderer>();
        
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        LR.SetPosition(0, mousePos);
        LR.SetPosition(1, mousePos);
    }
    void AddPoint(Vector2 pointPos)
    {
        //adds a point to the line renderer and sets it to where the mouse is
        LR.positionCount++;
        int positionIndex = LR.positionCount - 1;
        LR.SetPosition(positionIndex, pointPos);
    }
    public void Draw()
    {
        //creates the sealer line when you hold down the mouse
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateThing();
        }

        if(Input.GetKey(KeyCode.Mouse0))
        {
            //if you are holding down the mouse, it adds points to the line renderer as you move the mouse
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
            //turns off the line renderer when you let go of the mouse
            isDrawing = false;
            LR = null;
        }

    }
}
