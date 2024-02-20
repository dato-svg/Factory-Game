using System;
using Resources;
using Saver;
using UnityEngine;

public class BlockState : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private bool isBuy;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject canvas;
    [SerializeField] private BoxCollider boxCollider;
    
    private string KEY;
    [SerializeField] private BlockData blockData;
    
    
    private IServisSaver _servisSaver;

    private const string WorldBlock = "WorldBlock";
    private const string Canvas = "Canvas";

    private void Start()
    {
        KEY = gameObject.name;
        _servisSaver = new JsonServisRealize();
        if (_servisSaver.HasData(KEY))
        {
            LoadData();
        }
        
        ActiveObjectChek();

    }

    [ContextMenu("SaveData")]
    public void SaveData()
    {    
        blockData.IsActive = isActive;
        blockData.IsBuy = isBuy;
        blockData.Block = block;
        blockData.Canvas = canvas;
        blockData.BoxCollider = boxCollider;
        _servisSaver.Save(KEY, blockData); // TODO - another save system/ cloud
        
    }
    
    private void LoadData()
    {    
        _servisSaver.Load<BlockData>(KEY,LoadSystem); // TODO - another load system/ cloud
        
        
    }

    private void LoadSystem(BlockData block)
    {
        isActive = block.IsActive;
        isBuy = block.IsBuy;
        this.block = block.Block; 
        canvas = block.Canvas;
        boxCollider = block.BoxCollider;
        
    }

    public void ActivateActiveBool(bool isActive = false)
    {
        this.isActive = isActive;
        ActiveObjectChek();
    }
    
    public void ActivateIsBuyBool(bool isBuy = false)
    {
        this.isBuy = isBuy;
        ActiveObjectChek();
    }

    public void ActiveObjectChek()
    {    
        FindAllObject(WorldBlock, Canvas);
        if (isActive)
        {
            canvas.SetActive(true);
           
            boxCollider.enabled = true;
            if (isBuy)
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
        blockData.BoxCollider = GetComponent<BoxCollider>();

        Transform blockObj = transform.Find(blockName);
        block = blockObj.gameObject;
        blockData.Block = blockObj.gameObject;
        
        

        Transform canvasObj = transform.Find(canvasName);
        canvas = canvasObj.gameObject;
        blockData.Canvas = canvasObj.gameObject;
        
        if (block == null)
        {
            block = blockData.Block;
        }
        if (canvas == null)
        {
            canvas = blockData.Canvas;
        }
        if (boxCollider == null)
        {
            boxCollider = blockData.BoxCollider;
        }
        
    }
        

        

    }
    /*
    private async void Start()
    {    
        KEY =  gameObject.name;
        Load();
        

    }
    
    [ContextMenu("Save")]
    private void Save()
    {
        blockData.IsActive = IsActive;
        blockData.IsBuy = IsBuy;
        blockData.Block = Block;
        blockData.Canvas = Canvas;
        blockData.BoxCollider = BoxCollider;
        UnityCloudServisController.SaveData(KEY,blockData);
    }
    
    
    private async void Load()
    {
        var load = await UnityCloudServisController.LoadData<BlockData>(KEY);
        if (load != null)
        {
            IsActive = load.IsActive;
            IsBuy = load.IsBuy;
            Block = load.Block;
            Canvas = load.Canvas;
            BoxCollider = load.BoxCollider;
            
        }
    }
    */









[Serializable]
public class BlockData
{
    public bool IsActive;
    public bool IsBuy;
    public GameObject Block;
    public GameObject Canvas;
    public BoxCollider BoxCollider;

}
