using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using UnityEngine.Assertions;

public static class AssetsInjector
{
    private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);
    public static T Inject<T>(this AssetContext context, T target)
    {
        var targetType = target.GetType();        
        var allFields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        var methods = targetType.GetMethod("Do", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        Assert.IsNotNull(methods, "Method is null");

        for (int i = 0; i < allFields.Length; i++)
        {
            FieldInfo fieldInfo = allFields[i];
            var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;            

            if (injectAssetAttribute == null)
            {
                continue;
            }
            var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
            fieldInfo.SetValue(target, objectToInject);
        }
        return target;
    }
}