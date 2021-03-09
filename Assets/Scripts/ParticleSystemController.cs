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
