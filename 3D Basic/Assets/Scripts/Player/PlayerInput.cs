using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string       frontAxisName     = "Vertical";
    public string       rightAxisName     = "Horizontal";
    public string       fireButtonName    = "Fire1";
    public string       reloadButtonName  = "Reload";
    public float        frontMove  { get; private set; }
    public float        rightMove  { get; private set; }
    public bool         fire       { get; private set; }
    public bool         reload     { get; private set; }
    public Vector3      mousePos;
    public LayerMask    whatIsGround;

    void Update()
    {
        frontMove   = Input.GetAxis(frontAxisName);
        rightMove   = Input.GetAxis(rightAxisName);
        fire        = Input.GetButtonDown(fireButtonName);
        reload      = Input.GetButtonDown(reloadButtonName);

        Ray camRay  = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float depth = Camera.main.farClipPlane;

        if (Physics.Raycast(camRay, out hit, depth, whatIsGround))
        {
            mousePos = hit.point;
            //Debug.DrawRay(camRay.origin, camRay.direction * 20, Color.red, 5f);
            //Debug.Log(hit.point);

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mousePos, 0.5f);

    }
}
