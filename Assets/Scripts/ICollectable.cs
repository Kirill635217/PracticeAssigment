using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    enum Types
    {
        None, Sphere, Capsule
    }

    Types Type { get; }
    
    List<int> Value { get; }

    void Collected();

    void Initialize(List<int> value, ICollectable.Types type);
}
