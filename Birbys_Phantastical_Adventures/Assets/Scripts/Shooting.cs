using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public void onAttack(InputAction.CallbackContext context){
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}
