using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyBodyController myBody;
    //ParticleSystemController 
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponentInChildren<EnemyBodyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
