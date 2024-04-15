using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName = "Weapon";
    [SerializeField] private float shotsPerSeconds = 2;
    [SerializeField] private GameObject ordinancePrefab;
    [SerializeField] private WeaponBarrel weaponBarrel;
    [SerializeField] private float CoolDownTimer = 0;
    [SerializeField] private float muzzleVelocity;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        weaponBarrel = transform.GetComponentInChildren<WeaponBarrel>();
        muzzleVelocity = ordinancePrefab.GetComponent<Ordinance>().muzzleVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector3 parentVelocity)
    {
        float coolDownRate = 1 / shotsPerSeconds;
        
        _audioSource.Play();
    
        if (coolDownRate <= Time.time)
        {
            CoolDownTimer = Time.time + coolDownRate;
            GameObject newProyectile = Instantiate(ordinancePrefab, weaponBarrel.transform.position, weaponBarrel.transform.rotation) as GameObject;
            Rigidbody projRb = newProyectile.GetComponent<Rigidbody>();
            projRb.velocity = newProyectile.transform.forward * muzzleVelocity;
            Destroy(newProyectile, 5);
            
        }
    }
}
