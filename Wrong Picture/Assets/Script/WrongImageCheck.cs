using System.Collections.Generic;
using UnityEngine;

public class WrongImageCheck : Singleton<WrongImageCheck>
{
    [SerializeField] private List<WrongImage> left_WrongList = null;     // ���� ���� ������Ʈ ����
    [SerializeField] private List<WrongImage> right_WrongList = null;    // ������ ���� ������Ʈ ����

    private void Awake()
    {
        left_WrongList = GameManager.Inst.GetLeftWrongImageList;
        right_WrongList = GameManager.Inst.GetRightWrongImageList;
    }

    // ���޹��� ������Ʈ�� �ڽ� ������Ʈ�� Ȱ��ȭ��Ű�� �Լ���
    public void CheckImage(WrongImage _obj)
    {
        if (_obj.GetImageId <= 0) return;

        Debug.Log("���̵������ �����?");

        if (left_WrongList.Contains(_obj))
            FindWrongImage(left_WrongList, right_WrongList, _obj);
        else
            FindWrongImage(right_WrongList, left_WrongList, _obj);
    }

    // 
    public void FindWrongImage(List<WrongImage> _list1, List<WrongImage> _list2, WrongImage _obj)
    {
        int idx = 0;

        for (int i = 0; i < _list1.Count; i++)
            if (_list1[i] == _obj)
                idx = i;

        Debug.Log("üũ�� �����??");

        _list1[idx].SetCheck(true);
        _list2[idx].SetCheck(true);

        _list1[idx].transform.GetChild(0).gameObject.SetActive(true);
        _list2[idx].transform.GetChild(0).gameObject.SetActive(true);

        GameManager.Inst.SetScore(1);
    }
}
