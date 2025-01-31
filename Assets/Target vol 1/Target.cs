using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Target : MonoBehaviour, IDamage
{
    public float MaxHealth;
    public float Speed;
    public float TimeBeforeDown;
    public float PointsForDown;
    public Action<float> OnTargetDown;

    private float _currentHealth;
    private Collider _collider;


    void Start()
    {
        _currentHealth = MaxHealth;
        _collider = GetComponent<Collider>();
        if(_collider == null)
        {
            throw new System.NullReferenceException(nameof(_collider));
        }
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
#if DEVELOPMENT_BUILD
    _currentHealth = 0;
#endif
        GetComponent<AudioSource>().Play();

        Debug.Log("Health == " + _currentHealth);
        if (_currentHealth <= 0)
        {
            StartCoroutine(UpTarget());
            _collider.enabled = false;
            OnTargetDown?.Invoke(PointsForDown);
        }
    }

    private IEnumerator UpTarget()
    {
        while(transform.rotation.eulerAngles != new Vector3(90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), Speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(DownTarget());
    }
    private IEnumerator DownTarget()
    {
        yield return new WaitForSeconds(TimeBeforeDown);
        while (transform.rotation.eulerAngles != new Vector3(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), Speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        _currentHealth = MaxHealth;
        _collider.enabled = true;

    }

}
