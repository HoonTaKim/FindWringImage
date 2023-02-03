using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DIFFICULTY
{
    EASY,
    NORMAL,
    HARD,
    MASTER
}

public class GameDatas : MonoBehaviour
{
    public static GameDatas Inst;

    public DIFFICULTY difficulty;
    public float time;

    private int maxWrongImage;
    private int fixWrongImage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Inst == null) Inst = this;
        else Destroy(gameObject);
    }

    public int GetMaxWrongImage { get { return maxWrongImage; } private set { } }
    public int GetFixWrongImage { get { return fixWrongImage; } private set { } }

    public void SetMaxWrongImage(int _max) => maxWrongImage = _max;
    public void SetFixWrongImage(int _fix) => fixWrongImage = _fix;
}
