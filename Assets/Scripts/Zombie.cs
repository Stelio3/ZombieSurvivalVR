using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        rbs= GetComponentsInChildren<Rigidbody>();
        DeactivateRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death()
    {
        ActivateRagdoll();
    }
    private void ActivateRagdoll()
    {
        foreach(var item in rbs)
        {
            item.isKinematic = false;
        }
    }
    private void DeactivateRagdoll()
    {
        foreach (var item in rbs)
        {
            item.isKinematic = true;
        }
    }
}
