using System;
using UnityEngine;

namespace ExampleProject
{
    public interface IResourceManager
    {
        T CreatePrefabInstance<T, E>(E item) where E : Enum;
        GameObject CreatePrefabInstance<E>(E item) where E : Enum;
    }
}