using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTransformTool
{
    class FileFilter
    {
        /// <summary>
        /// 过滤器集合, 元素为后缀名
        /// </summary>
        private readonly ISet<string> filterSet;

        /// <summary>
        /// 文件过滤器的构造函数
        /// </summary>
        public FileFilter()
        {
            filterSet = new HashSet<string>();
        }

        /// <summary>
        /// 添加过滤属性
        /// </summary>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public bool addFilter(string suffix)
        {
            return filterSet.Add(suffix);
        }

        /// <summary>
        /// 批量添加过滤属性
        /// </summary>
        /// <param name="suffixs"></param>
        /// <returns></returns>
        public bool addFilters(string[] suffixs)
        {
            bool flag = false;
            foreach (string suffix in suffixs) 
            {
                if (addFilter(suffix))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// 添加过滤属性
        /// </summary>
        /// <param name="fileFilter"></param>
        /// <returns></returns>
        public bool addFilter(FileFilter fileFilter)
        {
            bool flag = false;
            foreach (string suffix in fileFilter.filterSet)
            {
                if (addFilter(suffix))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// 检查函数
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public bool check(FileInfo fileInfo)
        {
            return filterSet.Contains(FileUtil.getSuffix(fileInfo.Name));
        }

    }
}
