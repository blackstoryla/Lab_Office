using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Mono.Data.Sqlite;

[RequireComponent(typeof(XRBaseInteractable))]
public class Rifle : MonoBehaviour
{

    public Transform StartPoint;
    public float Range;
    public float TimeBetweenShots;
    public float DamagePerShot;
    public GameObject BulletWhole;
    public ParticleSystem Projectile;

    private XRBaseInteractable _grabble;
    private float _delay;

    void Start()
    {

        _grabble = GetComponent<XRBaseInteractable>();
        if (_grabble == null)
        {
            throw new System.NullReferenceException(nameof(_grabble));
        }
    }

    void Update()
    {
        _delay -= Time.deltaTime;
    }

    public void TryShoot()
    {
        if (!CheckCanShoot()) return;

        GetComponent<AudioSource>().Play();

        Projectile.Play();
        _delay = TimeBetweenShots;

        RaycastHit hit;
        if (!Physics.Raycast(StartPoint.transform.position, StartPoint.transform.forward, out hit, Range)) return;


        GameObject whole = Instantiate<GameObject>(BulletWhole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
        whole.transform.SetParent(hit.transform);

        Debug.Log("Hitted" + hit.transform.name);

        IDamage target = hit.transform.GetComponent<IDamage>();
        if (target == null) return;
        target.TakeDamage(DamagePerShot);


        //////////////////
        S_Database Base = new S_Database();

        long a = Base.Authorization("test", "123");

        Debug.Log("Authorization right " + a);

        if (a!=0)
        {
            Base.RecordTime(a);
        }
        //////////////////////


    }

    public bool CheckCanShoot()
    {
        if (_delay <= 0) return true;

        return false;
    }

    
}