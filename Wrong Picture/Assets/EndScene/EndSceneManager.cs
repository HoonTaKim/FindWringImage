using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    private GameData gd = null;

    [SerializeField] private TextMeshProUGUI scoreText = null;

    void Start()
    {
        scoreText.text = GameManager.Inst.GetScore.ToString();
    }
}
