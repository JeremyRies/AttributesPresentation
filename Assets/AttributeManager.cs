using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Callbacks;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    private List<Type> _cars;

    [DidReloadScripts]
    private static void ScriptReload()
    {
        Log();
    }
    
    private static void Log()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        List<Type> typesWithAttribute = new List<Type>();
        
        foreach (var assembly in assemblies)
        {
            typesWithAttribute.AddRange(GetTypesWithSpecialEnumAttribute(assembly));

        }
        
        Debug.Log("Matching type Count: " + typesWithAttribute.Count);
        
        
        foreach (var type in typesWithAttribute)
        {
            Debug.Log(type);
        }
    }


    static IEnumerable<Type> GetTypesWithSpecialEnumAttribute(Assembly assembly) {
        foreach(Type type in assembly.GetTypes()) {
            if (type.GetCustomAttributes(typeof(SpecialEnumAttribute), true).Length > 0) {
                yield return type;
            }
        }
    }

}