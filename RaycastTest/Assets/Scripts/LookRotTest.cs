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

            z ������ �ٶ󺸰� �ϴ� �Լ�.
            2D���� ���� ��������Ʈ�� �̻��� ���� �� ��
            �𸮾��ϰ� ����Ƽ�ϰ� �� �ٸ�
        #######################################*/

        Vector3 relativePos = target.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos); 
        this.transform.rotation = rotation;
    }
}
