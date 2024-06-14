using CustomAttributes;
using TMPro;
using UnityEngine;

public class TestClass : MonoBehaviour
{
    [CustomReadOnly]
    public int m_value = 10;
    [PrebuildGetComponent] [SerializeField] Rigidbody m_rigidbody;
    
    [PrebuildGetComponent][SerializeField]
    private AnotherTestClass m_class;

    [SerializeField] private TMP_Text m_text;

    private void Start()
    {
        m_text.SetText(m_rigidbody.mass.ToString());
    }
}