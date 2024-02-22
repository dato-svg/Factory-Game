using System;
using Assets.Scripts.Saver;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private TesterSave _testerSave;    
    public int number;
    
    
    public async void Start()
    {
        _testerSave = await UnityCloudServisController.LoadData<TesterSave>("test");
        if (_testerSave != null)
        {
            number = _testerSave.nubm;
            Debug.Log("Data loaded successfully.");
        }

    }

    [ContextMenu("Save")]
    public void Save()
    {
        _testerSave.nubm = number;
        UnityCloudServisController.SaveData("test",_testerSave);
    }
}

[Serializable]
public class TesterSave
{
    public int nubm;
}
