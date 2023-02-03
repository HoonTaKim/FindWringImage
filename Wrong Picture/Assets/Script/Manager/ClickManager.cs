using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [Header("=====Prefab=====")]
    [SerializeField] private GameObject errorObj = null;
    [SerializeField] private GameObject okObj = null;
    [Header("=====Parent=====")]
    [SerializeField] private Transform singPerent = null;

    private Camera cam;
    private float maxDistance = 15f;
    private Vector3 mousePos;
    private int layerMask;

    private void Start()
    {
        maxDistance = float.MaxValue;
        cam = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("Interactable");
    }
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
            {
                mousePos = cam.ScreenToWorldPoint(touch.position);
                
                if (!GameManager.Inst.GetGameSet && !GameManager.Inst.GetTimeSet)
                {
                    Click(mousePos);
                }
            }
        }
    }

    // 클릭시 실행
    private void Click(Vector2 _pos)
    {
        RaycastHit2D hit = new RaycastHit2D();
        hit = Physics2D.Raycast(_pos, transform.forward, maxDistance, layerMask);
        Debug.DrawRay(_pos, transform.forward * 10, Color.red, 0.3f);

        if (hit.collider != null && hit.transform.TryGetComponent<Click_Interactable>(out Click_Interactable obj))
            if (!hit.transform.GetComponent<WrongImage>().GetCheck)
                obj.Interact();
        else
        {
            GameObject error = CheckInst(errorObj, mousePos);
            Destroy(error, 1f);
        }
    }

    // 클릭시 X표시
    private GameObject CheckInst(GameObject obj, Vector3 pos)
    {
        GameObject checkImage = Instantiate(obj, singPerent);
        checkImage.transform.position = new Vector3(pos.x, pos.y, -2f);

        checkImage.SetActive(true);

        return checkImage;
    }
}
