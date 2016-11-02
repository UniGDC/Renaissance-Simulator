#! /bin/sh

# This example downloads and installs Unity Editor version 5.4.2 on travis-ci cloud server.
# Another version of Unity can be grabbed from: http://unity3d.com/get-unity/download/archive, so please edit the link if the version of Unity changes.

echo 'Downloading from Unity for macOS from http://netstorage.unity3d.com/unity/b7e030c65c9b/MacEditorInstaller/Unity-5.4.2f2.pkg: '
curl -o Unity.pkg http://netstorage.unity3d.com/unity/b7e030c65c9b/MacEditorInstaller/Unity-5.4.2f2.pkg

echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /
