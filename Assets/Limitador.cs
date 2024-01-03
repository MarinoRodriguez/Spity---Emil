using UnityEngine;

public class Limitador : MonoBehaviour
{
    public Transform left, right;
    public static Vector3 percent25;
    public static float MinX, MaxX;
    private void Start()
    {
        Camera cam = Camera.main;
        var min = cam.ViewportToWorldPoint(new Vector3(0, 1, cam.nearClipPlane));
        var max = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        var pso = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane));

        MinX = min.x; 
        MaxX = max.x;

        percent25.y = (min.y - pso.y) * 0.75f;
        percent25.y += pso.y;

        var pos = left.position;
        pos.x = min.x + 1;
        left.position = pos;

        pos = right.position;
        pos.x = max.x - 1;
        right.position = pos;
    }
}
