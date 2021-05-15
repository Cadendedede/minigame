using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour
{
    public string Name;

    public Sprite Image;

    public string InteractText = "Press E to pickup this Crate";

    public virtual void OnInteract()
    {

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
