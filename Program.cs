using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskSample();
            //string s = 5.ToString("D2");
            //ManageFiles();
            //ImportFromExcel();
            //Testc();
            //TestB();
            //TestD();
            //PostPrefix();
            string t = ReceivedText("Mad_<Super>#visor*12*#34");
            Console.Read();
        }

        private static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }

        public static string ReceivedText(string S)
        {
            // WRITE DOWN YOUR CODE HERE
            
            char[] numArray = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            //List<string> strList = S.Split(numArray).ToList();
            List<string> strList = SplitAndKeep(S, numArray).ToList();
            string finalOut = "";
            bool insertAtLast = true;
            bool numericKeyOn = true;

            foreach (string item in strList)
            {
                string strOut = ""; //"Heloo";
                string tempStr = "";
                foreach (char c in item)
                {
                    switch (c)
                    {
                        case '*':
                            if (tempStr.Length - 1 >= 0)
                            {
                                tempStr = tempStr.Remove(tempStr.Length - 1, 1);
                            }
                            break;
                        case '<':
                            strOut = InsertTheTempTextToStr(strOut, tempStr, insertAtLast);
                            tempStr = "";
                            insertAtLast = false;
                            break;
                        case '>':
                            strOut = InsertTheTempTextToStr(strOut, tempStr, insertAtLast);
                            tempStr = "";
                            insertAtLast = true;
                            break;
                        case '#':
                            numericKeyOn = !numericKeyOn;
                            break;
                        default:
                            if (numericKeyOn)
                            {
                                tempStr += c.ToString();
                            }
                            else
                            {
                                if (!numArray.Contains(c))
                                {
                                    tempStr += c.ToString();
                                }
                            }
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(tempStr))
                {
                    strOut = InsertTheTempTextToStr(strOut, tempStr, insertAtLast);
                }

                finalOut += strOut;
            }

            
            return finalOut;
        }

        private static string InsertTheTempTextToStr(string baseStr, string tempStr, bool insertAtLast)
        {
            string strOutput = "";
            if (insertAtLast)
            {
                strOutput = baseStr.Insert(baseStr.Length, tempStr);
            }
            else
            {
                strOutput = baseStr.Insert(0, tempStr);
            }
            return strOutput;
        }

        private static void TestB()
        {
            int[][] arr = new int[6][];
            int[] sum = new int[16];
            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            for (int t = 0; t < 16; t++)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(arr[i][j]);
                        int firstRow = 0;

                    }
                }
            }

        }

        private static void Testc()
        {
            int totalTestCases = Convert.ToInt32(Console.ReadLine());
            while (totalTestCases > 0)
            {
                Console.ReadLine();
                char[] drones = Console.ReadLine().ToCharArray();
                int numOfOps = Convert.ToInt32(Console.ReadLine());
                while (numOfOps > 0)
                {
                    string[] tokens = Console.ReadLine().Split();
                    if (int.TryParse(tokens[0], out int a) && int.TryParse(tokens[1], out int b))
                    {
                        for (int k = 0; k < drones.Length; k++)
                        {
                            drones[k] = (k >= a && k <= b) ? (drones[k] == '<' ? '>' : '<') : drones[k];
                        }
                    }
                    numOfOps--;
                }
                Console.WriteLine(new string(drones));
                totalTestCases--;
            }

            //for (int c = 0; c < totalTestCases; c++)
            //{
            //    Console.ReadLine();
            //    char[] drones = Console.ReadLine().ToCharArray();
            //    int numOfOps = Convert.ToInt32(Console.ReadLine());
            //    for (int j = 0; j < numOfOps; j++)
            //    {
            //        string[] tokens = Console.ReadLine().Split();
            //        int a = int.Parse(tokens[0]);
            //        int b = int.Parse(tokens[1]);
            //        for (int k = 0; k < drones.Length; k++)
            //        {
            //            drones[k] = (k >= a && k <= b) ? (drones[k] == '<' ? '>' : '<') : drones[k];
            //        }
            //    }
            //    Console.WriteLine(new string(drones));
            //}
        }

        private static void TestD()
        {



            int totalTestCases = Convert.ToInt32(Console.ReadLine());
            while (totalTestCases > 0)
            {
                System.Collections.Generic.Dictionary<string, int> d;
                int linesInCurrentTestCase = Convert.ToInt32(Console.ReadLine());
                d = new System.Collections.Generic.Dictionary<string, int>();
                while (linesInCurrentTestCase > 0)
                {
                    string[] tokens = Console.ReadLine().Split();
                    if (tokens.Length == 2)
                    {
                        if (d.ContainsKey(tokens[0]))
                            d[tokens[0]] += Convert.ToInt32(tokens[1]);
                        else
                            d.Add(tokens[0], Convert.ToInt32(tokens[1]));
                    }
                    else
                    {
                        var maxValue = d.Values.Max();
                        StringBuilder stringBuilder = new StringBuilder();
                        var maxKeys = d.Where(x => x.Value == maxValue).Select(p => p.Key);
                        foreach (string name in maxKeys)
                        {
                            stringBuilder.Append(name + " ");
                        }
                        Console.WriteLine(stringBuilder.ToString().TrimEnd());
                    }
                    linesInCurrentTestCase--;
                }

                totalTestCases--;
            }
        }

        private static void PostPrefix()
        {
            int a = 0, b = 19;

            a += ++b + b++;
            a = 5 % 3;

            Console.WriteLine(a);
            Console.WriteLine(b);


        }
        private static void TaskSample()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            // Launch t1 
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                              Thread.CurrentThread.ManagedThreadId);
            // Wait for the task to finish.
            t1.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                  Task.CurrentId, taskData,
                                   Thread.CurrentThread.ManagedThreadId);
            });
            // Wait for the task to finish.
            t3.Wait();

            // Construct an unstarted task
            Task t4 = new Task(action, "gamma");
            // Run it synchronously
            t4.RunSynchronously();
            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t4.Wait();
        }

        private static void ImportFromExcel()
        {
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Ratish\Desktop\CreditStatementMay2019.xlsx");
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@"C:\Users\Ratish\Desktop\1.xlsx", FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }

            ISheet sheet = hssfwb.GetSheet("Sheet1");
            for (int row = 0; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    Console.WriteLine(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).DateCellValue));
                }
            }
        }



        static void ManageFiles()
        {
            string inputPath = @"E:\GALLERY\Sharu\Raw";
            string outputPath = @"E:\GALLERY\Sharu\Managed";

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            if (Directory.Exists(inputPath))
            {
                foreach (string f in Directory.GetFiles(inputPath, "*.*", SearchOption.TopDirectoryOnly))
                {
                    FileInfo fileInfo = new FileInfo(f);
                    string newDirectoryName = fileInfo.LastWriteTime.Year.ToString() + fileInfo.LastWriteTime.Month.ToString("D2") + fileInfo.LastWriteTime.Day.ToString("D2");
                    string copyPath = Path.Combine(outputPath, newDirectoryName);
                    if (!Directory.Exists(copyPath))
                        Directory.CreateDirectory(copyPath);

                    File.Copy(f, Path.Combine(copyPath, fileInfo.Name), false);

                }
            }
        }

    }
}
