using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Tank
{
    private void Update()
    {
        if (CurrentHealth <= 0)
            Die();
    }
}
