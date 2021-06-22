//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace envoy.ConfigMap
//{
//    public class StaticExtentions
//    {
//          internal static void AddLinkedJsonFile(this IConfigurationBuilder c, string relativePath, bool optional, bool reloadOnChange)
//        {
//            var fileInfo = c.GetFileProvider().GetFileInfo(relativePath);

//            if (TryGetSymLinkTarget(fileInfo.PhysicalPath, out string targetPath))
//            {
//                c.AddJsonFile(new PhysicalFileProvider(Path.GetDirectoryName(targetPath)), Path.GetFileName(targetPath), optional, reloadOnChange);
//            }
//            else
//            {
//                c.AddJsonFile(relativePath, optional, reloadOnChange);
//            }
//        }

//        private static bool TryGetSymLinkTarget(string path, out string target)
//        {
//            target = null;

//            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
//            {
//                if (Windows.IsSymbolicLink(path))
//                {
//                    target = Windows.GetSymbolicLinkTarget(path);
//                    return true;
//                }
//            }
//            else
//            {
//                UnixSymbolicLinkInfo symbolicLinkInfo = new UnixSymbolicLinkInfo(path);

//                if (symbolicLinkInfo.IsSymbolicLink)
//                {
//                    target = symbolicLinkInfo.ContentsPath;
//                    return true;
//                }
//            }
//            return false;
//        }
//    }
//}
