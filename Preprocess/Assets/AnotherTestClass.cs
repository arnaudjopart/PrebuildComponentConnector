using UnityEngine;

public class AnotherTestClass : MonoBehaviour
{
    [OnBuildGetComponent] [HideInInspector, SerializeField] Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AnotherTestClass: "+m_rigidbody.mass);
    }

    // Update is called once per frame

}
