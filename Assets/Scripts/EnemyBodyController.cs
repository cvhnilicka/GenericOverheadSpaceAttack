using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyController : MonoBehaviour
{
    BoxCollider2D myCollider;
    Animator myAnimator;
    bool isDead;
    int hitsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        isDead = false;
        hitsRemaining = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDead() { return this.isDead; }


    private void OnParticleCollision(GameObject other)
    {
        // layer 10 is currently the friendly bullet layer

        if (other.layer == 10)
        { 
            //Debug.Log("Enemy SHOT!");

            if (other.tag == this.tag)
            {
                hitsRemaining -= 1;
                if (hitsRemaining <= 0)
                {
                    isDead = true;
                    myAnimator.SetTrigger("Death");
                    Debug.Log(transform.parent.name + " is dead");
                }
            }

            //switch (other.tag)
            //{
            //    case "Red":
            //        Debug.Log("Shot by RED");
            //        break;
            //    case "Blue":
            //        Debug.Log("Shot by Blue");

            //        break;
            //    case "Purple":
            //        Debug.Log("Shot by Purple");

            //        break;
            //}
        }

    }
}
