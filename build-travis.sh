# This script actually builds the game.
# It uses the WebGLBuilder C# script placed in Assets/Editor/WebGLBuild.cs.

echo "Attempting to build the game for WebGL"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -executeMethod MyEditorScript.MyMethod
