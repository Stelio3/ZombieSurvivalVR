using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    public AudioClip deathAudio;
    public Transform target;
    private NavMeshAgent agent;
    private Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<XROrigin>().transform;
        DeactivateRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (Vector3.Distance(target.position, transform.position) < 1.5f)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void Death()
    {
        ActivateRagdoll();
        agent.enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(deathAudio);
        Destroy(gameObject, 10);
        Destroy(this);
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
