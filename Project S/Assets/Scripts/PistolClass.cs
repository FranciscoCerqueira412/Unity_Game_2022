using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PistolClass : MonoBehaviour
{
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
        if (weapons._weapons[0].GetComponent<MeshFilter>().mesh.name == "Pistol " + "Instance")
        {
            this.damage = 100;
            this.fireRate =100;

        }
        if (weapons._weapons[0].GetComponent<MeshFilter>().mesh.name == "Pistol1 " + "Instance")
        {
            this.damage = 5;
            this.fireRate = 400;
        }

    }
    public void ProjectilleShootPistol()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);



        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask) && Input.GetKey(KeyCode.Mouse1))
        {
            mouseWorldPosition = raycastHit.point;
        }

        Vector3 aimDir = (mouseWorldPosition - spawnBulletPositionPistol.position).normalized;
        if (_input.shoot)
        {
            if (currentAmmo > 0)
            {
                if (CanShoot())
                {
                    Instantiate(bulletPrefabPistol, spawnBulletPositionPistol.position, Quaternion.LookRotation(aimDir));
                    _input.shoot = false;
                    currentAmmo--;
                    timeSinceLastShot = 0;
                    OnGunShot();
                }
            }


        }
        StartReload();
    }

    public bool CanShoot() => reloading && timeSinceLastShot > 1f / (fireRate / 60f);
    public void OnGunShot()
    {

    }

    public void StartReload()
    {
        if (currentAmmo < 1 || (Input.GetKey(KeyCode.R) && currentAmmo < magSize))
        {
            StartCoroutine(Reload());
        }


    }

    public IEnumerator Reload()
    {
        reloading = false;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magSize;
        reloading = true;
    }

}

