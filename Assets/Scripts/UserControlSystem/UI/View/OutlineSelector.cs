using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OutlineSelector : MonoBehaviour
{
    [SerializeField] private MeshRenderer [] _renderers;
    [SerializeField] private Material _outlineMaterial;

    private bool _isSelectedCache;

    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedCache)
        {
            return;
        }
        for (int i = 0; i < _renderers.Length; i++)
        {
            var renderer = _renderers[i];
            var materialslList = renderer.materials.ToList();
            if (isSelected)
            {
                materialslList.Add(_outlineMaterial);
            }
            else
            {
                materialslList.RemoveAt(materialslList.Count - 1);
            }
            renderer.materials = materialslList.ToArray();
        }
        _isSelectedCache = isSelected;
    }    
}
