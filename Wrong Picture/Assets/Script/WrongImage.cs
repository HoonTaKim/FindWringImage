using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongImage : MonoBehaviour, Click_Interactable
{
    [SerializeField] private WrongImage linkImage = null;
    public void SetLinkImage(WrongImage _linkImage) => linkImage = _linkImage;

    [SerializeField] private int imageId = 0;
    public int GetImageId { get { return imageId; } private set { } }
    public void SetImageId(int _id) => imageId = _id;

    private bool check = false;
    public bool GetCheck { get { return check; } private set { } }

    public void SetCheck(bool _check) => check = _check;

    private Sprite sp = null;

    private int randomIdx = 0;

    private List<Sprite> wrongImageList = null;
    private List<Sprite> answerImageList = null;

    private void Awake()
    {
        wrongImageList = FindObjectOfType<WrongImageManager>().GetwrongImageList;
        answerImageList = FindObjectOfType<WrongImageManager>().GetAnswerImageList;
    }

    //private void OnEnable()
    //{
    //    if (!GameManager.Inst.GetSpriteCheck)
    //    {
    //        randomIdx = Random.Range(0, wrongImageList.Count);
    //        this.gameObject.GetComponent<SpriteRenderer>().sprite = answerImageList[randomIdx];
    //    }
    //}

    private void Start()
    {
        this.gameObject.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.01f, 1);
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(10, 10);
        sp = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        check = false; 
    }

    public void Interact()
    {
        if (check) return;

        // 판단을 해주는 스크립트의 함수 호출
        WrongImageCheck.Inst.CheckImage(this);
        check = true;
    }

    public void On_ChangeImage()
    {
        randomIdx = Random.Range(0, wrongImageList.Count);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = wrongImageList[randomIdx];
    }
    public void On_ChangeImageLayer() => this.gameObject.layer = 9;
    public void Object_Off() => this.gameObject.SetActive(false);
}
