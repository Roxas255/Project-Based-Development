using UnityEngine;
using UnityEngine.InputSystem;

public class CaulkScript : MonoBehaviour
{
    public Texture2D caulkTexture;
    public bool isHolding = false;
    void Start()
    {
    }

    void Update()
    {     
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPoint);

        if(Input.GetKey(KeyCode.Mouse0) && isHolding)
        {
            //caulk stuff here
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && isHolding)
        {
            //stop caulking stuff here
        }
    }
    
    public void ChangeCursor()
    {            
        Cursor.SetCursor(caulkTexture, Vector2.zero, CursorMode.Auto);
        isHolding = true;
    }
}
