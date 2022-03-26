using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Health health;
    //TESTING//
    bool triggered = false;
    [SerializeField] bool testKill = false;

    public void OnRaycastHit()
    {
        /*health.TakeDamage(weapon.damage);*/
        health.TakeDamage(101);
    }

    private void Update()
    {
        if (testKill && !triggered)
        {
            OnRaycastHit();
            triggered = true;
        }
    }

}
