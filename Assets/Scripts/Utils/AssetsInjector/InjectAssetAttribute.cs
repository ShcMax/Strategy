using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[AttributeUsage(AttributeTargets.Field)]
public sealed class InjectAssetAttribute : Attribute
{
    public readonly string AssetName;

    public InjectAssetAttribute(string assetName = null)
    {
        AssetName = assetName;
    }
}
