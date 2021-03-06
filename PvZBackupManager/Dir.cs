﻿using System;
using System.Collections.Generic;
using System.IO;

namespace PvZBackupManager
{
    static class Dir
    {
        /// <summary>
        /// 删除文件夹
        /// </summary>
        public static void Delete(string path)
        {
            path = FormatPath(path);
            if (!Directory.Exists(path))
            {
                throw new Exception("无法删除文件夹，因为文件夹不存在");
            }
            else
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    Delete(dir);
                }
                foreach (var file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                Directory.Delete(path);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        public static void Delete(string path, bool checkUse)
        {
            if (checkUse && IsAnyFileInUse(path))
            {
                throw new Exception("无法删除文件夹，因为有文件被占用");
            }
            Delete(path);
        }

        /// <summary>
        /// 复制文件夹
        /// </summary>
        public static void Copy(string sourcePath, string destiPath)
        {
            sourcePath = FormatPath(sourcePath);
            destiPath = FormatPath(destiPath);
            if (!Directory.Exists(sourcePath))
            {
                throw new Exception("无法复制文件夹，因为源文件夹不存在");
            }
            else if (Directory.Exists(destiPath))
            {
                throw new Exception("无法复制文件夹，因为目标文件夹已存在");
            }
            else
            {
                Directory.CreateDirectory(destiPath);
                foreach (var dir in Directory.GetDirectories(sourcePath))
                {
                    Copy(dir, destiPath + GetName(dir));
                }
                foreach (var file in Directory.GetFiles(sourcePath))
                {
                    File.Copy(file, destiPath + GetName(file));
                }
                string GetName(string path)
                {
                    int index = path.LastIndexOf('\\');
                    if (index >= 0)
                        return path.Substring(index);
                    else
                        return path;
                }
            }
        }

        /// <summary>
        /// 复制文件夹
        /// </summary>
        public static void Copy(string sourcePath, string destiPath, bool checkUse)
        {
            if (checkUse && (IsAnyFileInUse(sourcePath) || IsAnyFileInUse(destiPath)))
            {
                throw new Exception("无法复制文件夹，因为有文件被占用");
            }
            Copy(sourcePath, destiPath);
        }

        /// <summary>
        /// 移动文件夹
        /// </summary>
        public static void Move(string sourcePath, string destPath)
        {
            Copy(sourcePath, destPath);
            Delete(sourcePath);
        }

        /// <summary>
        /// 移动文件夹
        /// </summary>
        public static void Move(string sourcePath, string destPath, bool checkUse)
        {
            Copy(sourcePath, destPath, checkUse);
            Delete(sourcePath, checkUse);
        }

        /// <summary>
        /// 格式化文件夹路径
        /// </summary>
        public static string FormatPath(string path)
        {
            path = path.Replace('/', '\\');
            while (path.EndsWith(@"\") && path.Length > 0)
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path;
        }

        /// <summary>
        /// 获取路径中所有文件路径
        /// </summary>
        public static string[] GetFileList(string path)
        {
            List<string> list = new List<string>();

            void List(string _path)
            {
                foreach(var dir in Directory.GetDirectories(_path))
                {
                    List(dir);
                }
                foreach(var file in Directory.GetFiles(_path))
                {
                    list.Add(file);
                }
            }

            List(path);

            return list.ToArray();
        }

        /// <summary>
        /// 判断文件是否被占用
        /// </summary>
        public static bool IsFileInUse(string path)
        {
            bool inUse = true;
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                inUse = false;
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return inUse;
        }

        /// <summary>
        /// 判断路径中是否有文件被占用
        /// </summary>
        public static bool IsAnyFileInUse(string path)
        {
            foreach(var file in GetFileList(path))
            {
                if (!File.Exists(file))
                    continue;

                if (IsFileInUse(file))
                    return true;
            }
            return false;
        }
    }
}
