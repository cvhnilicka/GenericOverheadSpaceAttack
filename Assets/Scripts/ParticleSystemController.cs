using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemController : MonoBehaviour
{
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //ParentRotation();
        //ParentVel();
    }

    void ParentVel()
    {
        var main = particleSystem.main;
        main.startSpeed = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.y + main.startSpeed.constant;
        //main.
        //particleSystem.inheritVelocity.enabled = true;
    }

    void ParentRotation()
    {
        var main = particleSystem.main;
        main.startRotationZ = transform.parent.localRotation.z;
        //main.startRotation = transform.parent.rotation.z;
        
    }

    public void Deactivate()
    {
        var emission = particleSystem.emission;
        emission.enabled = false;
    }

    public void Activate()
    {
        var emission = particleSystem.emission;
        emission.enabled = true;
    }
}
