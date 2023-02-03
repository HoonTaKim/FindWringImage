using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int score = 0;

    [SerializeField] private UiManager uiManager = null;
    [SerializeField] private WrongImageManager wrongImageManager = null;
    [SerializeField] private CreateBoard createBoard = null;

    private BoardSeting boardSeting = null;
    private bool spriteCheck = false;

    // Board1의 이미지 데이터
    private List<WrongImage> left_WrongList = null;
    // Board2의 이미지 데이터
    private List<WrongImage> right_WrongList = null;

    List<bool> clearSequence = new List<bool>();
    private bool gameClear = false;
    private bool timeOver = false;
    private int maxWrongImage = 0;
    private int fixWrongImage = 0;
    private float curTime = 0f;

    #region return
    public WrongImageManager GetWrongImageManager { get { return wrongImageManager; } private set { } }
    public CreateBoard GetCreateBoard { get { return createBoard; } private set { } }
    public bool GetSpriteCheck { get { return spriteCheck; } private set { } }
    public List<WrongImage> GetLeftWrongImageList { get { return left_WrongList; } private set { } }
    public List<WrongImage> GetRightWrongImageList { get { return right_WrongList; } private set { } }
    public bool GetGameSet { get { return gameClear; } private set { } }
    public bool GetTimeSet { get { return timeOver; } private set { } }
    public int GetMaxWrongImage { get { return maxWrongImage; } private set { } }
    public int GetFixWrongImage { get { return fixWrongImage; } private set { } }
    public int GetScore { get { return score; } private set { } }
    #endregion

    void Start()
    {
        curTime = 100f;

        // 난이도에 따라서 maxScore값 변경되는 기능 구현해야함 아마 SelectLevel같은거 만들면댈듯
        maxWrongImage = GameDatas.Inst.GetMaxWrongImage;
        fixWrongImage = GameDatas.Inst.GetFixWrongImage;
    }

    private void Update()
    {
        // 시간 추가
        if (!gameClear && !timeOver)
        {
            if (curTime <= 0)
            {
                timeOver = true;
                uiManager.SliderTime(0);
                clearSequence.Add(timeOver);
            }

            if (score == maxWrongImage + fixWrongImage)
            {
                gameClear = true;
                clearSequence.Add(gameClear);
            }

            curTime -= Time.deltaTime;
            uiManager.SliderTime(curTime); 
        }

        // 게임오버 판정 추가
        // if문으로 틀린그림이 몇개인지 스코어가 n개와 같은지 판단
        if (gameClear || timeOver)
        {
            GameSet();
        }

    }

    public void SetScore(int _score)
    {
        score += _score;
    }

    public void GameSet()
    {
        SceneManager.LoadScene("Additive_EndScene");
    }

    public void SetLeftWrongList(List<WrongImage> _array)
    {
        left_WrongList = _array;
        Debug.Log("GameManager : " + left_WrongList.Count);
    }

    public void SetRightWrongList(List<WrongImage> _list)
    {
        right_WrongList = _list;
    }

    public void SetBoardSeting(BoardSeting _bs)
    {
        boardSeting = _bs;
    }

    public void SetSpriteCheck(bool _check) 
    {
        spriteCheck = _check;
    }
}
