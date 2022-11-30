using System.Collections.Generic;

public interface ICollectable
{
    enum Types
    {
        None, Sphere, Capsule
    }

    Types Type { get; }
    
    List<int> Value { get; }

    void Collected();

    void Initialize(List<int> value, Types type);
}
