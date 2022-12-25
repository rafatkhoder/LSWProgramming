using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour
{
    public static InputManger Instance;

    private float horizontal;
    private float vertical;

    public bool PanelButton;
    public bool mouseButton;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        mouseButton = Input.GetMouseButtonDown(0);
    }

    public bool InvetoryInput()
    {
       return PanelButton = Input.GetKeyDown(KeyCode.P);
    }

    public float XMoving()
    {
        return horizontal = Input.GetAxis(GameStrings.Horizontal);
    }
    public float YMoving()
    {
        return vertical = Input.GetAxis(GameStrings.Vertical);
    }
   

}