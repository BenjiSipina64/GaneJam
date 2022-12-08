using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRocketThings : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private GameObject rocketTip;
    public float launchForce;
    public int startTrackingAfterSecs;
    public float rocketSpeed;
    private Vector3 rot;
    private Ray dir;
    
    void Start()
    {
        rigidbody.AddForce(transform.up * launchForce, ForceMode.Impulse);
    }
    
    void Update()
    {
        StartCoroutine(TrackTarget());
    }

    private IEnumerator TrackTarget()
    {
        yield return new WaitForSeconds(startTrackingAfterSecs);
        
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.forward * (launchForce * 2), ForceMode.Impulse);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        dir = new Ray( rocketTip.transform.position, target.transform.position);
        Gizmos.DrawRay(dir);
    }
}
