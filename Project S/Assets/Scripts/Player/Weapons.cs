using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using StarterAssets;

public class Weapons : MonoBehaviour
{
    public StarterAssetsInputsCustom _input;


    public GameObject[] _weapons;
    public float aimDuration;
    public Rig headLook;
    public Rig PistolAim;
    public Rig MachineGunAim;
    public RigBuilder rigBuilder;
    public Mesh[] pistolMeshes;
    public Mesh[] machineGunMeshes;
    bool isPistol;
    bool isMachineGun;

    public GameObject holster;
    public GameObject backHolster;


    ItemDragHandler itemHand;
    //[Header("Caracteristicas das armas")]

    private void Start()
    {
        itemHand = FindObjectOfType<ItemDragHandler>();
    }



    private void Update()
    {

        RigChanging();
        ChangePoseWeapon();
        //PistolClass();
    }



    void ChangePoseWeapon()
    {

        if (_input.aim)
        {
            if (isMachineGun == true && isPistol == false)
            {
                PistolAim.weight = 0;
                headLook.weight = 1;
                MachineGunAim.weight += Time.deltaTime / aimDuration;

            }
            if (isMachineGun == false && isPistol == true)
            {
                MachineGunAim.weight = 0;
                headLook.weight = 1;
                PistolAim.weight += Time.deltaTime / aimDuration;


            }

        }
        else
        {
            headLook.weight = 0;

            PistolAim.weight -= Time.deltaTime / aimDuration;
            MachineGunAim.weight -= Time.deltaTime / aimDuration;

        }
    }

    void RigChanging()
    {
        if (Input.GetKey(KeyCode.Alpha1) && holster.transform.childCount>0)
        {
            //Pistol
            isMachineGun = false;
            isPistol = true;
            rigBuilder.layers[0].active = true;
            rigBuilder.layers[1].active = true;
            rigBuilder.layers[2].active = true;
            rigBuilder.layers[3].active = true;
            rigBuilder.layers[4].active = false;
            rigBuilder.layers[5].active = false;
            rigBuilder.layers[6].active = false;
            _weapons[0].SetActive(true);
            _weapons[1].SetActive(false);
            holster.transform.GetChild(0).gameObject.SetActive(false);
            if (backHolster.transform.childCount > 0)
            {
                backHolster.transform.GetChild(0).gameObject.SetActive(true);
            }
            


            if (Input.GetKeyDown(KeyCode.J))
            {
                //_weapons[0].GetComponent<MeshFilter>().mesh = pistolMeshes[Random.Range(0, 13)];
            }

        }
        if (Input.GetKey(KeyCode.Alpha2) && backHolster.transform.childCount > 0)
        {
            //MachineGun
            isPistol = false;
            isMachineGun = true;
            rigBuilder.layers[0].active = true;
            rigBuilder.layers[1].active = false;
            rigBuilder.layers[2].active = false;
            rigBuilder.layers[3].active = false;
            rigBuilder.layers[4].active = true;
            rigBuilder.layers[5].active = true;
            rigBuilder.layers[6].active = true;
            _weapons[1].SetActive(true);
            _weapons[0].SetActive(false);
            if (holster.transform.childCount > 0)
            {
                holster.transform.GetChild(0).gameObject.SetActive(true);
            }
            
            backHolster.transform.GetChild(0).gameObject.SetActive(false);
            _weapons[1].GetComponentInChildren<MeshFilter>().mesh = backHolster.transform.GetChild(0).GetComponent<MeshFilter>().mesh;

            //if (Input.GetKeyDown(KeyCode.K))
            //{
            //    _weapons[1].GetComponentInChildren<MeshFilter>().mesh = machineGunMeshes[Random.Range(0, 17)];
            //}
            //ChangePoseMachineGun();

        }

        else if (Input.GetKey(KeyCode.P))
        {
            rigBuilder.layers[0].active = true;
            rigBuilder.layers[1].active = false;
            rigBuilder.layers[2].active = false;
            rigBuilder.layers[3].active = false;
            rigBuilder.layers[4].active = false;
            rigBuilder.layers[5].active = false;
            rigBuilder.layers[6].active = false;
            holster.transform.GetChild(0).gameObject.SetActive(true);
            backHolster.transform.GetChild(0).gameObject.SetActive(true);

            foreach (GameObject weapons in _weapons)
                weapons.SetActive(false);
        }
    }

    void PistolClass()
    {
        if (_weapons[0].active)
        {
            //Pistola1
            if (_weapons[0].GetComponent<MeshFilter>().mesh.name == "Pistol " + "Instance")
            {
                //Caracteristicas da arma
                Debug.Log("PISTOLA 1 EM USO");
            }
        }

    }

}
