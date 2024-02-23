using System;
using System.Threading.Tasks;
using Assets.Scripts.Saver;
using Resources;
using UnityEngine;

public class BlockState : MonoBehaviour
{
    [SerializeField] private int isActive;
    [SerializeField] private int isBuy;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject canvas;
    [SerializeField] private BoxCollider boxCollider;
    private string KEY;


    private const string WorldBlock = "WorldBlock";
    private const string Canvas = "Canvas";

    private async void Start()
    {
        KEY = gameObject.name;
        LoadSystem();
        ActiveObjectChek();
        
    }
    
    
    [ContextMenu("SaveData")]
    public async void SaveData()
    {
        ResourcesData.SaveResources(KEY+"IsActive1",isActive);
        ResourcesData.SaveResources(KEY+"IsBuy1",isBuy);
    }

    
    [ContextMenu("LoadData")]
    private void LoadSystem()
    {
        ResourcesData.LoadResources(KEY+"IsActive1",ref isActive);
        ResourcesData.LoadResources(KEY+"IsBuy1",ref isBuy);
    }

    public void ActivateActiveBool(int isActive = 0)
    {
        this.isActive = isActive;
        ActiveObjectChek();
        SaveData();
    }
    
    public void ActivateIsBuyBool(int isBuy = 0)
    {
        this.isBuy = isBuy;
        ActiveObjectChek();
        SaveData();
    }

    public  void ActiveObjectChek()
    {    
       FindAllObject(WorldBlock, Canvas);
        if (isActive == 1)
        {
            canvas.SetActive(true);
           
            boxCollider.enabled = true;
            if (isBuy == 1)
            {    
                Debug.Log("Canvas OFF");
                canvas.SetActive(false); 
                boxCollider.enabled = false;
                block.SetActive(true);
            }
        }
        else
        {
            block.SetActive(false);
            canvas.SetActive(false);
            boxCollider.enabled = false;
        }
        
    }

    private void FindAllObject(string blockName, string canvasName)
    {
        boxCollider = GetComponent<BoxCollider>();
        
        Transform blockObj = transform.Find(blockName);
        block = blockObj.gameObject;
        
        Transform canvasObj = transform.Find(canvasName);
        canvas = canvasObj.gameObject;
        
        
        
    }
        

        

    }
   





