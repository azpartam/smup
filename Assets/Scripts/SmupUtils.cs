using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//is game object completely out of the screen
static class SmupUtils
{
    static public bool IsGameObjectOnScreen(Vector3 extents, Vector3 position)
    {
        Vector3 screenUpperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.x));
        Vector3 screenLowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.x));
        return ((position.z - extents.z > screenUpperRight.z) ||
            (position.z + extents.z < screenLowerLeft.z) ||
            (position.y - extents.y > screenUpperRight.y) ||
            (position.y + extents.y < screenLowerLeft.y));
    }
}
