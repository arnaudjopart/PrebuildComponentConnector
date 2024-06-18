using System;
using System.Reflection;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class OnBuildGetComponentAttribute : PropertyAttribute, IPrebuildGetComponent
{
    public void Apply(FieldInfo _info,Component _component, GameObject _content)
    {
        _info.SetValue(_component,_content.GetComponent(_info.FieldType));
        Debug.Log(_content.name+" got component connected in PreBuild Process: "+_info.FieldType);
        //Debug.Log((_content.GetComponent(_info.FieldType) as Rigidbody).mass);
    }
}

public interface IPrebuildGetComponent
{
    void Apply(FieldInfo _info, Component _component, GameObject _content);
}
