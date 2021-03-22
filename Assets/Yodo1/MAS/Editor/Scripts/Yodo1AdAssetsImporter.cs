using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Yodo1.MAS
{
    public class Yodo1AdAssetsImporter : AssetPostprocessor
    {
        public override int GetPostprocessOrder()
        {
            // Apply this postprocessor early
            return 0;
        }

        void OnPreprocessAsset()
        {
            if (assetPath.Contains("Version.md"))
            {
                //DeleteFiles_Deprecated();
                Yodo1AdSettings settings = Yodo1AdSettingsSave.Load();
                Yodo1AdSettingsSave.UpdateDependencies(settings);
#if UNITY_2018_1_OR_NEWER
#else

                Yodo1PostProcess.GenerateGradle(settings);
#endif
            }
        }
    }
}
