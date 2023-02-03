using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{
    [SerializeField] private GameObject board = null;

    void Start()
    {
        Board_Seting(-0.53f, -0.1f);  // 왼쪽 보드 생성
    }

    // 해당위치에 보드 생성
    public void Board_Seting(float _posX, float _posY)
    {
        GameObject boardOn = Instantiate(board);
        boardOn.transform.position = new Vector3(_posX, _posY, 0);
    }
}
