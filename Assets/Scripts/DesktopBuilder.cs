//using UnityEditor;
//class DesktopBuilder {
//    static void buildDesktop() {

//        // Place all your scenes here
//        string[] scenes = {"Assets/Scenes/main.unity"};

//        string pathToDeploy = "builds/WebGLversion/";       

//        BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);      
//    }

//        static void buildWebgl() {

//        // Place all your scenes here
//        string[] scenes = {"Assets/Scenes/main.unity"};

//        string pathToDeploy = "builds/WebGLversion/";       

//        BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);      
//    }
//}

/** 
https://docs.unity3d.com/Manual/CommandLineArguments.html


on cmd use
    set mypath=%cd%
    @echo %mypath%
    "C:\Program Files\Unity\Editor\Unity.exe" -quit -batchmode -logFile stdout.log -projectPath %mypath% -executeMethod DesktopBuilder.buildDesktop
 */