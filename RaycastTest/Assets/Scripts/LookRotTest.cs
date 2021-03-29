using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotTest : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        /*#######################################
            Quaternion.LookRotation(Vector3 pos);

            z 값으로 바라보게 하는 함수.
            2D에서 쓰면 스프라이트가 이상한 곳을 볼 것
            언리얼하고 유니티하고 또 다름
        #######################################*/

        Vector3 relativePos = target.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos); 
        this.transform.rotation = rotation;
    }
}
