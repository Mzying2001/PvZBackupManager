﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PvZBackupManager.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PvZBackupManager.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 cd /d {0}
        ///attrib *.* /s /d -r -s
        ///
        ///cd /d {1}
        ///attrib *.* /s /d -r -s 的本地化字符串。
        /// </summary>
        internal static string attrib {
            get {
                return ResourceManager.GetString("attrib", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似于 (图标) 的 System.Drawing.Icon 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Icon icon {
            get {
                object obj = ResourceManager.GetObject("icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   查找 System.Drawing.Bitmap 类型的本地化资源。
        /// </summary>
        internal static System.Drawing.Bitmap icon_72px {
            get {
                object obj = ResourceManager.GetObject("icon_72px", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 v1.0.9
        ///- 年度加强版运行时恢复不会导致存档丢失
        ///（该版本恢复年度加强版存档仍需先关闭游戏）
        ///
        ///v1.0.8
        ///+ 添加对Zoo日文版的支持
        ///* 修改Windows XP下存档管理器的文档目录
        ///
        ///v1.0.7
        ///- 修复了一些问题
        ///
        ///v1.0.6
        ///+ 新建/重命名支持回车确定
        ///* 调整“关于”界面
        ///
        ///v1.0.5
        ///- 修复“访问被拒绝”的bug
        ///
        ///v1.0.4
        ///+ 支持Windows XP
        ///+ 支持自选路径
        ///* 新增图标
        ///* 调整窗口布局
        ///* 限制窗口多开
        ///* 调整默认备份名
        ///* 限制备份名长度
        ///（图标来源 www.easyicon.net）
        ///
        ///v1.0.3
        ///+ 添加对Steam版的支持
        ///
        ///v1.0.2
        ///- 修复出现空白选项的bug
        ///- 修复重命名/删除存档错误的bug
        ///
        ///v1.0.1
        ///+ 双击恢复存档
        ///+ 右键更多选项
        ///* 窗口可以随意调整大小
        ///* 加大存档列表的字体大小
        ///（该版本没有在网上发布，但在网盘链接里有该版本源代码）
        ///
        ///v1.0.0
        ///+ 初始发布
        ///
        ///----------------------------- [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string updatelog {
            get {
                return ResourceManager.GetString("updatelog", resourceCulture);
            }
        }
    }
}