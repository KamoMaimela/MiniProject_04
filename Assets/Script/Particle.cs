using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float LifeTime = 0.5f;

    void Start()
    {
        Invoke("DestroyParticles", LifeTime);

    }

    void DestroyParticles()
    {
        Destroy(gameObject);
    }
}
