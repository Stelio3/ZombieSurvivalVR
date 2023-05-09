using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb : MonoBehaviour
{
    public bool fatal = false;
    public GameObject limbPrefab;
    public void Hit()
    {
        Limb childLimb = transform.GetChild(0).GetComponentInChildren<Limb>();
        if (childLimb != null)
            childLimb.Hit();

        transform.localScale= Vector3.zero;

        GameObject spawnedLimb = Instantiate(limbPrefab, transform.parent);
        spawnedLimb.transform.parent = null;
        Destroy(spawnedLimb, 10);
        Destroy(this);

        if(fatal)
        {
            GetComponentInParent<Zombie>().Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
            Hit();
    }
}
