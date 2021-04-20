using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int lv = 1;

    public void OnCollisionEnter2D(Collision2D cl) {
        Hero pl = cl.gameObject.GetComponent<Hero>();
        if (cl.gameObject.name == "Hero")
        {
            pl.GetDamage();
            lv--;
        }
        if (lv < 1)
            Die();
    }

    public virtual void GetDamage(){
        
    }

    public virtual void Die(){
        Destroy(this.gameObject);
    }
}
