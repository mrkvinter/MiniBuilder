using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
/*
namespace Engine.PoolManager.Editor
{
    [CustomPropertyDrawer(typeof(PoolTag))]
    public class PoolTagEditor : PropertyDrawer
    {
        private Tuple<string, int>[] GetValuePoolTags()
        {
            var type = typeof(PoolTag);
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(int))
                .Select(f => new Tuple<string, int>(f.Name, (int) f.GetValue(null)))
                .ToArray();
        }
    }
}*/