using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    public Color color = Color.red;
    public float radius = 0.4f;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
