
using UnityEngine;

public static class RaycastUtility
{
    public static RaycastHit2D CastRayFromMouse()
    {
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Physics2D.Raycast(mousePoint, Vector2.zero);
    }
}