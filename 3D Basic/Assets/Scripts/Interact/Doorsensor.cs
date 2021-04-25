using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorsensor : MonoBehaviour
{
    public float openTime = 2f; //문이 열려있는 시간
    public float openSpeed = 5f; // 열리는 속도
    public Vector3 openDistance = new Vector3(0, 3, 0); //열리는 거리

    private bool isOpen = false;
    private Vector3 originPoint;
    private Vector3 targetPosition = Vector3.zero;

    private void Awake()
    {
        originPoint = transform.parent.position; //부모의 포지션을 저장한다.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PLAYER"))
        {
            if (isOpen)
            {
                StopCoroutine("StayOpen");
            }
            OpenDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PLAYER"))
        {
            StartCoroutine("StayOpen");
        }
    }

    private void OpenDoor()
    {
        if (isOpen) return;
        targetPosition = originPoint + openDistance;
        isOpen = true;
    }

    private IEnumerator StayOpen()
    {
        yield return new WaitForSeconds(openTime);
        CloseDoor();
    }

    private void CloseDoor()
    {
        isOpen = false;
    }

    void Update()
    {
        if (isOpen)
        { //열리고있을 경우
            Vector3 nextPos = Vector3.Lerp(transform.parent.position,
                                           targetPosition,
                                           Time.deltaTime * openSpeed);
            transform.parent.position = nextPos;

        }
        else
        {  //닫히고 있을 경우
            if ((transform.parent.position - originPoint).sqrMagnitude >= 0.01f)
            {
                Vector3 nextPos = Vector3.Lerp(
                    transform.parent.position,
                    originPoint,
                    Time.deltaTime * openSpeed
                );

                transform.parent.position = nextPos;
            }
        }
    }
}