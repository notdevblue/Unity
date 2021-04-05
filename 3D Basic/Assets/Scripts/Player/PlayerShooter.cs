using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if(playerInput.fire)
        {
            gun.Fire();
        }

        if(playerInput.reload)
        {
            if(gun.Reload())
            {
                // 여기 리로딩 애니메이션
            }
        }
    }



}
