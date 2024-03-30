using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// BuilderScript�N���X
/// </summary>
public class BuilderScript
{
    /// <summary>
    /// Build���\�b�h
    /// �r���h���郁�\�b�h
    /// </summary>
    public static void Build()
    {
        // �r���h�I�v�V����
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            target = BuildTarget.StandaloneWindows64,
            locationPathName = "Release/Out.exe",
            scenes = GetAllScenes()
        };

        // �r���h���s
        UnityEditor.Build.Reporting.BuildReport reports = BuildPipeline.BuildPlayer(options);
        EditorApplication.Exit(0);
    }

    /// <summary>
    /// GetAllScenePaths���\�b�h
    /// �r���h�Ɋ܂߂�K�v������V�[���̃��X�g���擾���郁�\�b�h
    /// </summary>
    /// <returns>�V�[��</returns>
    public static string[] GetAllScenes()
    {
        return EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
    }

    /// <summary>
    /// BuildMenu���\�b�h
    /// ���j���[����r���h�����s���郁�\�b�h
    /// </summary>
    [MenuItem("Build/Build")]
    public static void BuildMenu()
    {
        Build();
    }
}
