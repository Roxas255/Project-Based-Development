using UnityEngine;
using UnityEngine.InputSystem;

public class CaulkScript : MonoBehaviour
{
    public bool isHolding = false;
    void Start()
    {
        Vector2 startPos = transform.position;
    }

    void Update()
    {     
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
        Collider2D hitCollider = Physics2D.OverlapPoint(worldPoint);
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isHolding)
        {
            if (hitCollider != null)
            {
                if (hitCollider.gameObject == gameObject)
                {
                    isHolding = true;
                }
            }
        }

        if (isHolding == true)
        {
            transform.position = worldPoint;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && isHolding)
        {
            //caulk stuff here
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && isHolding)
        {
            isHolding = false;
        }

    }
}
