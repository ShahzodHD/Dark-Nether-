using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIDie : MonoBehaviour
{
    public PlayerController playerCtrl;
    void Start()
    {
        playerCtrl = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerCtrl.health < 1)
        {
            Destroy(gameObject);
        }
    }
}
