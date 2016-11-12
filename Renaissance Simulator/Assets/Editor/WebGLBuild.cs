// Command-line usage: $ /path/to/Unity -quit -batchmode -executeMethod WebGLBuilder.Build
// Please add new scenes if there are some changes.

using UnityEditor;

class WebGLBuilder
{
    static void Build()
    {
        string[] Scenes = new string[] { "Assets/Scenes/MenuScreen.unity", "Assets/Scenes/Tutorial.unity" };
        BuildPipeline.BuildPlayer(Scenes, "Build", BuildTarget.WebGL, BuildOptions.None);
    }
}
