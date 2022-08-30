using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSystemManager : MonoBehaviour
{
    public static TestSystemManager Instance;
    public bool TestMode { get => testMode; }
    [SerializeField] private bool testMode;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}
