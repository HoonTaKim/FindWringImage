using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private int easy_MaxWrongImage;
    [SerializeField] private int easy_FixWrongImage;

    [SerializeField] private int normal_MaxWrongImage;
    [SerializeField] private int normal_FixWrongImage;

    [SerializeField] private int hard_MaxWrongImage;
    [SerializeField] private int hard_FixWrongImage;

    [SerializeField] private int master_MaxWrongImage;
    [SerializeField] private int master_FixWrongImage;

    public void Click_Easy()
    {
        Debug.Log("Easy");
        GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        WrongImageCountSeting(easy_MaxWrongImage, easy_FixWrongImage);
        SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Normal()
    {
        Debug.Log("Normal");
        GameDatas.Inst.difficulty = DIFFICULTY.NORMAL;
        //WrongImageCountSeting(easy_MaxWrongImage, easy_FixWrongImage);
        SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Hard()
    {

        Debug.Log("Hard");
        GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        GameDatas.Inst.SetMaxWrongImage(6);
        GameDatas.Inst.SetFixWrongImage(2);
        SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Master()
    {
        Debug.Log("Master");
        GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        GameDatas.Inst.SetMaxWrongImage(8);
        GameDatas.Inst.SetFixWrongImage(3);
        SceneManager.LoadScene("2.GameScene");
    }

    private void WrongImageCountSeting(int _max, int _fix)
    {
        GameDatas.Inst.SetMaxWrongImage(_max);
        GameDatas.Inst.SetFixWrongImage(_fix);
    }
}