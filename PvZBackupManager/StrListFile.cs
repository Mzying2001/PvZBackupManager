using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace PvZBackupManager
{
    class StrListFile : List<string>
    {

        private readonly string path;

        public new string this[int index]
        {
            get
            {
                return base[index];
            }
            private set
            {
                base[index] = value;
            }
        }

        public StrListFile(string path)
        {
            this.path = path;
            if (!File.Exists(path))
            {
                File.WriteAllText(path, null);
            }
            foreach(var tmp in Regex.Split(File.ReadAllText(path), "\r\n"))
            {
                string str = tmp.Trim();
                if (str.Length != 0)
                {
                    try
                    {
                        Add(str);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        ~StrListFile()
        {
            Save();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        public void Save()
        {
            string str = "";
            foreach(var tmp in this)
            {
                str += tmp + "\r\n";
            }
            str = str.Trim();
            File.WriteAllText(path, str);
        }

        /// <summary>
        /// 加入字符串
        /// </summary>
        /// <param name="item"></param>
        public new void Add(string item)
        {
            item = item.Trim();
            if (!Contains(item))
            {
                if (item.Length == 0)
                {
                    throw new Exception("加入的字符串不能为空");
                }
                else
                {
                    base.Add(item);
                }
            }
            else
            {
                throw new Exception("该项已存在");
            }
        }

        /// <summary>
        /// 重命名相应字符串
        /// </summary>
        /// <param name="item"></param>
        /// <param name="newname"></param>
        public void Rename(string item,string newname)
        {
            this[IndexOf(item)] = newname;
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="item"></param>
        public void Up(string item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                throw new Exception("找不到字符串");
            }
            else
            {
                if (index > 0)
                {
                    RemoveAt(index);
                    Insert(index - 1, item);
                }
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="item"></param>
        public void Down(string item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                throw new Exception("找不到字符串");
            }
            else
            {
                if (index < Count - 1)
                {
                    RemoveAt(index);
                    Insert(index + 1, item);
                }
            }
        }

        /// <summary>
        /// 移到最前
        /// </summary>
        /// <param name="item"></param>
        public void ToTop(string item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                throw new Exception("找不到字符串");
            }
            else
            {
                if (index > 0)
                {
                    RemoveAt(index);
                    Insert(0, item);
                }
            }
        }

        /// <summary>
        /// 移到最后
        /// </summary>
        /// <param name="item"></param>
        public void ToBottom(string item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                throw new Exception("找不到字符串");
            }
            else
            {
                if (index < Count - 1)
                {
                    RemoveAt(index);
                    Add(item);
                }
            }
        }

    }
}
