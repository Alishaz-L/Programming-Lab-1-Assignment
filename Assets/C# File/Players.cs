using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{

    [SerializeField] private float speed;
    private Vector3 _moveDir;
    private Vector2 currentAngle;

    [Header("Camera")]
    [SerializeField, Range(1, 20)] private float mouseSenseX;
    [SerializeField, Range(1, 20)] private float mouseSenseY;
    [SerializeField, Range(0, 90)] private float maxViewAngle;
    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField] private Transform followTarget;

    [Header("Shooting")]
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] public float projectileForce;

    [Header("Player UI")]
    [SerializeField] private UnityEngine.UI.Image ammoBar;
    [SerializeField] private TextMeshProUGUI ammoFired;

    [SerializeField] private float maxAmmo;
    private float _ammo;

    // Add the ammoFiredCounter field
    [SerializeField] public static int ammoFiredCounter;

    public AudioSource source;
    public AudioClip clip;

    [SerializeField] private Bullet stats;


    private float Ammo
    {
        get => _ammo;
        set
        {
            _ammo = value;
            ammoBar.fillAmount = _ammo / maxAmmo;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoFiredCounter = 15;

        // Starting the game in GameMode
        Inputs.Init(this);
        Inputs.GameMode();

        Ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDir;
        Ammo -= Time.deltaTime * 5;

        // Check for left mouse button click
       
    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDir = currentDirection;
    }

    public void SetLookRotation(Vector2 readValue)
    {
        currentAngle.x += readValue.x * Time.deltaTime * mouseSenseX;
        currentAngle.y += readValue.y * Time.deltaTime * mouseSenseY;

        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);

        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);
    }

    public void shoot()
    {
        
        Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);

        Bullet bulletScript = currentProjectile.GetComponent<Bullet>(); // Get the Bullet component from the projectile

        if (bulletScript != null)
        {
            if (((int)bulletScript.BulletType & (int)Bullet.EProjectileType.Legendary) == (int)Bullet.EProjectileType.Legendary)
            {
                Debug.Log("Legendary!");
                
            }
            else
            {
                Debug.Log("NOT Legendary");
            }
        }

        if (ammoFiredCounter != 0)
        {   
            ammoFiredCounter--;
            ammoFired.text = ammoFiredCounter.ToString();
            Destroy(currentProjectile.gameObject, 4);
        }
        else
        {
            Destroy(currentProjectile.gameObject);
        }
    }

    public void Reload()
    {
        if (ammoFiredCounter == 0)
        {
            ammoFiredCounter = 15;
            ammoFired.text = ammoFiredCounter.ToString();
        }
    }
}
