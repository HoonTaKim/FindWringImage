using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSeting : MonoBehaviour
{
    [Header("=====Inst Size=====")]
    [SerializeField] private int widthObj;          // 가로에 배치될 오브젝트 개수
    [SerializeField] private int heightObj;         // 세로에 배치될 오브젝트 개수

    [Header("=====Prefab=====")]
    [SerializeField] WrongImage defalt_obj = null;  // 기본 오브젝트
    [SerializeField] WrongImage copy_Obj = null;    // 기본 오브젝트를 복사할 오브젝트
    [SerializeField] GameObject answer_Obj = null;  // 정답 표시 오브젝트

    [Header("=====Object Inst Position=====")]
    [SerializeField] private float objectPos_X;
    [SerializeField] private float objectPos_Y;
    
    private int wrongCount = 0; // 틀린그림 개수
    private int fixCount = 0;

    private List<Sprite> spriteList;   // 틀린그림 스프라이트 리스트
    private List<Sprite> wrongSpriteList;   // 틀린그림 스프라이트 리스트

    private List<WrongImage> leftWrongList;  // 왼쪽 보드의 오브젝트 리스트
    private List<WrongImage> rightWrongList; // 오른쪽 보드의 오브젝트 리스트

    private void Awake()
    {
        leftWrongList = new List<WrongImage>();
        rightWrongList = new List<WrongImage>();
        spriteList = GameManager.Inst.GetWrongImageManager.GetAnswerImageList;
        wrongSpriteList = GameManager.Inst.GetWrongImageManager.GetwrongImageList;

        Debug.Log("spriteList : " + spriteList.Count);
        Debug.Log("wrongSpriteList : " + wrongSpriteList.Count);
    }

    private void Start()
    {
        wrongCount = GameManager.Inst.GetMaxWrongImage;
        fixCount = GameManager.Inst.GetFixWrongImage;

        if (!GameManager.Inst.GetSpriteCheck)
            CreateBoard();
        else
        {
            CopyBoard();
            LinkedWrongImage();
        }
    }

    private void CreateBoard()
    {
        GenerateObject();

        GameManager.Inst.SetLeftWrongList(leftWrongList);
        GameManager.Inst.GetCreateBoard.Board_Seting(0.53f, -0.1f);
        GameManager.Inst.SetSpriteCheck(true);
    }

    // 보드 생성
    private void GenerateObject()
    {
        WrongImage obj = null;
        int randomIdx = 0;
        int id = 1;
        for (int i = 0; i < wrongCount + fixCount; i++)
        {

            obj = Instantiate<WrongImage>(defalt_obj, this.transform);
            // 위치 겹칠수도있기때문에 수정해야함
            float randomPivot_X = Random.Range(-objectPos_X, objectPos_X);
            float randomPivot_Y = Random.Range(-objectPos_Y, objectPos_Y);
            obj.transform.localPosition += Vector3.right * randomPivot_X + Vector3.up * randomPivot_Y + Vector3.back;
            obj.SetImageId(id);
            obj.On_ChangeImageLayer();
            ChildCreate(obj);

            randomIdx = Random.Range(0, spriteList.Count);
            obj.GetComponent<SpriteRenderer>().sprite = spriteList[randomIdx];
            id++;
            leftWrongList.Add(obj);
        }
    }

    // 복사본 생성
    private void CopyBoard()
    {
        leftWrongList = GameManager.Inst.GetLeftWrongImageList;
        for (int i = 0; i < leftWrongList.Count; i++)
        {
            WrongImage copy = Instantiate(copy_Obj);
            copy.transform.parent = this.gameObject.transform;
            copy.transform.localPosition = leftWrongList[i].transform.localPosition;

            if (leftWrongList[i].gameObject.layer == 9)
            {
                copy.On_ChangeImageLayer();
                copy.SetImageId(leftWrongList[i].GetImageId);
                ChildCreate(copy);
                int random = Random.Range(0, spriteList.Count);
                copy.GetComponent<SpriteRenderer>().sprite = wrongSpriteList[random];
            }
            rightWrongList.Add(copy);
        }
        GameManager.Inst.SetRightWrongList(rightWrongList);
    }

    // 서로같은 아이디값을 가진 오브젝트들을 연결
    public void LinkedWrongImage()
    {
        for (int i = 0; i < leftWrongList.Count; i++)
        {
            leftWrongList[i].SetLinkImage(rightWrongList[i]);
            rightWrongList[i].SetLinkImage(leftWrongList[i]);
        }
    }

    // 틀린그림 오브젝트 하위에 정답 오브젝트 추가
    private void ChildCreate(WrongImage _obj)
    {
        GameObject answer = Instantiate(answer_Obj, _obj.transform.position, Quaternion.identity, _obj.transform);
        answer.transform.localScale = new Vector3(1, 1, 1);
        answer.SetActive(false);
    }
}
