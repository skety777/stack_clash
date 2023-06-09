#if UNITY_2021_3_OR_NEWER
using System;
using System.IO;
using System.Security;
using System.Security.Permissions;
using Newtonsoft.Json;
using Unity.Services.Core.Internal;
using UnityEditor.Build;
using UnityEngine;

namespace Unity.Services.Core.Configuration.Editor
{
    class ProjectConfigurationBuildInjectorWithPlayerProcessor : BuildPlayerProcessor
    {
        internal const string IoErrorMessage = "Service configuration file couldn't be created."
            + " Be sure you have read/write access to your project's Library folder.";

        internal static readonly string ConfigCachePath
            = Path.Combine(AssetUtils.CoreLibraryFolderPath, ConfigurationUtils.ConfigFileName);

        public override void PrepareForBuild(BuildPlayerContext buildPlayerContext)
        {
            var config = ProjectConfigurationBuilder.CreateBuilderWithAllProvidersInProject()
                .BuildConfiguration();
            CreateProjectConfigFile(config);
            buildPlayerContext.AddAdditionalPathToStreamingAssets(ConfigCachePath);
        }

        internal static void CreateProjectConfigFile(SerializableProjectConfiguration config)
        {
            try
            {
                if (!Directory.Exists(AssetUtils.CoreLibraryFolderPath))
                {
                    Directory.CreateDirectory(AssetUtils.CoreLibraryFolderPath);
                }

                using (new JsonConvertDefaultSettingsScope())
                {
                    var serializedConfig = JsonConvert.SerializeObject(config);
                    File.WriteAllText(ConfigCachePath, serializedConfig);
                }
            }
            catch (SecurityException e)
                when (e.PermissionType == typeof(FileIOPermission)
                      && FakePredicateLogError())
            {
                // Never reached to avoid stack unwind.
            }
            catch (UnauthorizedAccessException)
                when (FakePredicateLogError())
            {
                // Never reached to avoid stack unwind.
            }

            bool FakePredicateLogError()
            {
                Debug.LogError(IoErrorMessage);
                return false;
            }
        }
    }
}
#endif
