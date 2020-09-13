using System;
using System.Collections.Generic;
using System.IO;

namespace PvZBackupManager
{
    class StrListFile : List<string>
    {

        private readonly string path;

        public new string this[int index]
        {
            get => base[index];

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
            foreach (var tmp in File.ReadAllText(path).Split('\n'))
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
            string str = string.Empty;

            foreach(var tmp in this)
            {
                str += tmp + "\n";
            }

            File.WriteAllText(path, str.Trim());
        }

        /// <summary>
        /// 加入字符串
        /// </summary>
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
        public void Rename(string item, string newname)
        {
            this[IndexOf(item)] = newname;
        }

        /// <summary>
        /// 上移
        /// </summary>
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
