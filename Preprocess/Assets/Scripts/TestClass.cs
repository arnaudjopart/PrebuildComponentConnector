﻿using System;
using CustomAttributes;
using TMPro;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    private void Start()
    {
        m_text.SetText(m_rigidbody.mass.ToString()+"-test");
    }

    [CustomReadOnly]
    public int m_value = 10;

    [OnBuildGetComponent][HideInInspector, SerializeField] Rigidbody m_rigidbody;
    [OnBuildGetComponent][HideInInspector, SerializeField] AnotherTestClass m_class;

    [SerializeField] private TMP_Text m_text;
    
}