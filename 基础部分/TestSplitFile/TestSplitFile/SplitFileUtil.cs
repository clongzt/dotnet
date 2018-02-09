using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSplitFile
{
    public class SplitFileUtil
    {
        /// <summary>
        /// 输入文件名
        /// </summary>
        /// <param name="file"></param>
        /// <param name="splitFileFormat"></param>
        public  static void SplitFile(string file,string splitFileFormat)
        {
          
            long splitMinFileSize = unchecked(10 * 1024 * 1024 * 1204);
            int splitFileSize = 20 * 1024 * 1024;

            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Length > splitMinFileSize)
            {
                Console.WriteLine("判定结果：需要分隔文件！");
            }
            else
            {
                Console.WriteLine("判定结果：不需要分隔文件！");
                Console.ReadKey();
                return;
            }

            int steps = (int)(fileInfo.Length / splitFileSize);
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int couter = 1;
                    bool isReadingComplete = false;
                    while (!isReadingComplete)
                    {
                        string filePath = string.Format(splitFileFormat, couter);
                        Console.WriteLine("开始读取文件【{1}】：{0}", filePath,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                        byte[] input = br.ReadBytes(splitFileSize);
                        using (FileStream writeFs = new FileStream(filePath, FileMode.Create))
                        {
                            using (BinaryWriter bw = new BinaryWriter(writeFs))
                            {
                                bw.Write(input);
                            }
                        }

                        isReadingComplete = (input.Length != splitFileSize);
                        if (!isReadingComplete)
                        {
                            couter += 1;
                        }
                        Console.WriteLine("完成读取文件【{1}】：{0}", filePath,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    }
                }
            }
        }
}
