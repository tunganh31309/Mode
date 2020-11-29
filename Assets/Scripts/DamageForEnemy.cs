using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageForEnemy : MonoBehaviour
{
    public float damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHpManager>().DmgEnemy(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        }
    }
}
