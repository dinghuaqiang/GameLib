using UnityEngine;

namespace GameLib.Core.Utils
{
    public class PathProviderFactory
    {
        private static IPathProvider _provider = null;
        public static IPathProvider CreateProvider(int buildType, bool isMainProject)
        {
            switch (buildType)
            {
                case 0:
                    if (isMainProject)
                    {
                        return new PathProviderMainEditor();
                    }
                    else
                    {
                        return new PathProviderEditor();
                    }
                case 1:
                    return new PathProviderIOS();
                case 2:
                    return new PathProviderAndroid();
                case 3:
                    return new PathProviderWin();
                case 4:
                    return new PathProviderWebGL();
                default:
                    Debug.LogError("BuildType set fail!!" + buildType);
                    return null;
            }
        }
    }
}
