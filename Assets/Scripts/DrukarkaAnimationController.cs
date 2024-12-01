using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrukarkaAnimationController : MonoBehaviour
{
    private List<HitboxHitAction> actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actions = gameObject.GetComponent<WorkingColliders>().actions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
