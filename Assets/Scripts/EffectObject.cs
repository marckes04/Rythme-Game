using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifeTime = 1f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject(gameObject, lifeTime);
    }
}
