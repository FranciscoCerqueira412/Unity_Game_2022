using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MachineGunClass : MonoBehaviour
{
    public Animator MachingeGunRIG;
    Weapons weapons;
    public StarterAssetsInputsCustom _input;
    [SerializeField] LayerMask aimColliderLayerMask = new LayerMask();

    //[Header("Caracteristicas das armas")]
    public float damage;
    public float maxDistance;
    public int currentAmmo;

    public int magSize;
    public int fireRate;
    public float reloadTime;
    public bool reloading;
    public bool canReload;


    private float timeSinceLastShot;

    public Transform bulletPrefabPistol;
    public Transform spawnBulletPositionPistol;

    public Transform bulletPrefabMachinegun;
    public Transform spawnBulletPositionMachinegun;
    RaycastHit hit;

    private void Start()
    {
        weapons = FindObjectOfType<Weapons>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
    public void ProjectilleShootMachineGun()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);



        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask) && Input.GetKey(KeyCode.Mouse1))
        {
            mouseWorldPosition = raycastHit.point;
        }

        Vector3 aimDir = (mouseWorldPosition - spawnBulletPositionMachinegun.position).normalized;
        if (Input.GetMouseButton(0))
        {
            if (currentAmmo > 0)
            {
                if (CanShoot() && canReload==true)
                {
                    Instantiate(bulletPrefabMachinegun, spawnBulletPositionMachinegun.position, Quaternion.LookRotation(aimDir));
                    currentAmmo--;
                    timeSinceLastShot = 0;
                    OnGunShot();
                }
            }
            
        }
        if (Input.GetMouseButton(0) && _input.aim && Input.GetKey(KeyCode.R))
        {
            StartReload();
        }
        else
        {
            StartReload();
        }
        


    }


    public bool CanShoot() => reloading && timeSinceLastShot > 1f / (fireRate / 60f);
    public void OnGunShot()
    {

    }

    public void StartReload()
    {
        if ((currentAmmo < 1 &&canReload==true) ||(Input.GetKeyDown(KeyCode.R) && currentAmmo < magSize && canReload == true))
        {
            canReload = false;
            MachingeGunRIG.SetTrigger("Reload_MachineGun");
            Debug.Log("ANIMAÇAO RELOAD");
            Invoke("Reload",reloadTime);

        }

    }

    public void Reload()
    {
            reloading = false;
            currentAmmo = magSize;
            reloading = true;
            canReload = true;

    }



}

