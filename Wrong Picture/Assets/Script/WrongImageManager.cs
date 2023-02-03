using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongImageManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> wrongImageList = new List<Sprite>();
    [SerializeField] private List<Sprite> answerImageList = new List<Sprite>();

    public List<Sprite> GetwrongImageList { get { return wrongImageList; } private set { } }
    public List<Sprite> GetAnswerImageList { get { return answerImageList; } private set { } }
}
