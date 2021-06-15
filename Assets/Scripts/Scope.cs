using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Scope : MonoBehaviour
{

    public Animator animator;
   // private bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public float scopedFOV = 15f;
    public float normalFOV;

    bool scopeFree = true;
    bool mouseIsNotOverUI;

    public static Scope instance;


    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (WinLoseScreen.Instance.GetisGameEnd())
            return;
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonDown(0)&&mouseIsNotOverUI)
        {
            if (scopeFree)
            {
                scopeFree = false;
                StartCoroutine(OnScoped());
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(OnUnScoped());
        }
    }

    IEnumerator OnScoped()
    {
        animator.SetBool("Scoped", true);

        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    IEnumerator OnUnScoped()
    {

        yield return new WaitForSeconds(0f);
        animator.SetBool("Scoped", false);

        scopeFree = true;
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCamera.fieldOfView = normalFOV;

    }
}
