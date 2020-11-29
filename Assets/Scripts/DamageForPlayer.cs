using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForPlayer : MonoBehaviour
{
    public float damageToGive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHPmanager>().DmgPlayer(damageToGive);
        }
    }
}
