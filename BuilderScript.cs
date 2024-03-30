using System.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>
/// BuilderScriptクラス
/// </summary>
public class BuilderScript
{
    /// <summary>
    /// Buildメソッド
    /// ビルドするメソッド
    /// </summary>
    public static void Build()
    {
        // ビルドオプション
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            target = BuildTarget.StandaloneWindows64,
            locationPathName = "Release/Out.exe",
            scenes = GetAllScenes()
        };

        // ビルド実行
        UnityEditor.Build.Reporting.BuildReport reports = BuildPipeline.BuildPlayer(options);
        EditorApplication.Exit(0);
    }

    /// <summary>
    /// GetAllScenePathsメソッド
    /// ビルドに含める必要があるシーンのリストを取得するメソッド
    /// </summary>
    /// <returns>シーン</returns>
    public static string[] GetAllScenes()
    {
        return EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
    }

    /// <summary>
    /// BuildMenuメソッド
    /// メニューからビルドを実行するメソッド
    /// </summary>
    [MenuItem("Build/Build")]
    public static void BuildMenu()
    {
        Build();
    }
}
