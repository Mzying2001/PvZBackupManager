using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PvZBackupManager
{
    class StrListFile : List<string>
    {

        private readonly string path;

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

        public int GetIndex(string item)
        {
            int index = -1;
            for(int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public string[] GetItems()
        {
            return ToArray();
        }

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
                    Save();
                }
            }
            else
            {
                throw new Exception("该项已存在");
            }
        }

        public new void Remove(string item)
        {
            base.Remove(item);
            Save();
        }

        public void Rename(string item,string newname)
        {
            this[GetIndex(item)] = newname;
            Save();
        }

        public void Swap(string item1,string item2)
        {
            int index1 = GetIndex(item1);
            int index2 = GetIndex(item2);
            if (index1 == -1 || index2 == -1)
            {
                throw new Exception("找不到欲交换的字符串");
            }
            else
            {
                string tmp = this[index1];
                this[index1] = this[index2];
                this[index2] = tmp;
                Save();
            }
        }

        public void Up(string item)
        {
            int index = GetIndex(item);
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
                    Save();
                }
            }
        }

        public void Down(string item)
        {
            int index = GetIndex(item);
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
                    Save();
                }
            }
        }

        public void ToTop(string item)
        {
            int index = GetIndex(item);
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
                    Save();
                }
            }
        }

        public void ToBottom(string item)
        {
            int index = GetIndex(item);
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
                    Save();
                }
            }
        }

    }
}
