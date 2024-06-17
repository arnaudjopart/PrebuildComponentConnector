using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;


public class BuildPipelineTest : IPostprocessBuildWithReport
{


    public int callbackOrder { get; }
    public void OnPostprocessBuild(BuildReport report)
    {
        Debug.Log(report.steps);
    }
}
