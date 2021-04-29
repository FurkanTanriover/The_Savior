using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{

    public Animator animator;
    private bool isScoped=false;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public float scopedFOV = 15f;
    private float normalFOV;


    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped",isScoped);

           if(isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnScoped();
            }
        }
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(isScoped);
        weaponCamera.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }
}
