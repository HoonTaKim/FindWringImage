using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    // 게임 종료시에 사용
    private int gameScore = 0;

    private int wrongImageCount = 0;
    private int wrongImageFix = 0;

    public int GetGameScore { get { return gameScore; } private set { } }
    public int GetWrongImageCount { get { return wrongImageCount; } private set { } }
    public int GetWrongImageFix { get { return wrongImageFix; } private set { } }

    public void SetGameScore(int _score) => gameScore = _score;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    
}
