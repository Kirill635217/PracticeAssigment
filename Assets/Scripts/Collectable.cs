using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Collectable : MonoBehaviour, ICollectable
{
    
    [SerializeField] private List<int> value;
    [SerializeField] private ICollectable.Types type;
    
    public ICollectable.Types Type => type;
    
    public List<int> Value => value;
    
    public void Initialize(List<int> value, ICollectable.Types type)
    {
        this.value = value;
        this.type = type;
    }

    public virtual void Collected()
    {
        Destroy(gameObject);
    }

}