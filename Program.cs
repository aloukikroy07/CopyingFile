using System;
using System.IO;

namespace CopyingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter source path: ");
                string sourcePath = Console.ReadLine();
                Console.Write("Enter destination path: ");
                string tpath = Console.ReadLine();
                //Console.Write("Enter number of files in a folder: ");
                //int nofiles = Int32.Parse(Console.ReadLine());
                string fileName = string.Empty;
                string destFile = string.Empty;
                string targetPath = tpath + @"\";
                int count = 0;
                //int lcount = 1;
                //string desdir = "";

                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);
                    Console.WriteLine("Please wait.....");

                    foreach (string s in files)
                    {
                        DateTime creation = File.GetCreationTime(s);
                        int dt = creation.Day;
                        string wk = GetWeek(dt);
                        string mnth = creation.ToString("MMMM");
                        int yr = creation.Year;
                        string pathOfYear = targetPath + yr;
                        string pathOfMonth = pathOfYear + @"\"+mnth;
                        string pathOfWeek = pathOfMonth + @"\" + wk;
                        string pathOfDate = pathOfWeek + @"\" + dt;

                        if(System.IO.Directory.Exists(pathOfYear))
                        {
                            if(System.IO.Directory.Exists(pathOfMonth))
                            {
                                if(System.IO.Directory.Exists(pathOfWeek))
                                {
                                    if(System.IO.Directory.Exists(pathOfDate))
                                    {
                                        fileName = System.IO.Path.GetFileName(s);
                                        destFile = System.IO.Path.Combine(pathOfDate, fileName);
                                        System.IO.File.Copy(s, destFile, true);
                                        count++;
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(pathOfDate);

                                        fileName = System.IO.Path.GetFileName(s);
                                        destFile = System.IO.Path.Combine(pathOfDate, fileName);
                                        System.IO.File.Copy(s, destFile, true);
                                        count++;
                                    }
                                }
                                else
                                {
                                    Directory.CreateDirectory(pathOfWeek);
                                    Directory.CreateDirectory(pathOfDate);

                                    fileName = System.IO.Path.GetFileName(s);
                                    destFile = System.IO.Path.Combine(pathOfDate, fileName);
                                    System.IO.File.Copy(s, destFile, true);
                                    count++;
                                }
                            }
                            else
                            {
                                Directory.CreateDirectory(pathOfMonth);
                                Directory.CreateDirectory(pathOfWeek);
                                Directory.CreateDirectory(pathOfDate);
                                
                                fileName = System.IO.Path.GetFileName(s);
                                destFile = System.IO.Path.Combine(pathOfDate, fileName);
                                System.IO.File.Copy(s, destFile, true);
                                count++;
                            }

                        }

                        else
                        {
                            Directory.CreateDirectory(pathOfYear);
                            Directory.CreateDirectory(pathOfMonth);
                            Directory.CreateDirectory(pathOfWeek); 
                            Directory.CreateDirectory(pathOfDate);

                            fileName = System.IO.Path.GetFileName(s);
                            destFile = System.IO.Path.Combine(pathOfDate, fileName);
                            System.IO.File.Copy(s, destFile, true);
                            count++;
                        }

                        //if (count % nofiles == 0 || count == 1)
                        //{
                        //    string subPath = "Folder " + lcount;
                        //    string dir = targetPath + subPath;
                        //    desdir = dir;
                        //    Directory.CreateDirectory(dir);
                        //    fileName = System.IO.Path.GetFileName(s);
                        //    destFile = System.IO.Path.Combine(dir, fileName);
                        //    System.IO.File.Copy(s, destFile, true);
                        //    count++;
                        //    lcount++;
                        //}
                        //else
                        //{
                        //    fileName = System.IO.Path.GetFileName(s);
                        //    destFile = System.IO.Path.Combine(desdir, fileName);
                        //    System.IO.File.Copy(s, destFile, true);
                        //    count++;
                        //}

                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
                Console.Clear();
                Console.WriteLine("Transfer successful. Total " + count + " files transfered.");
                Console.WriteLine("Press any key or close the window for exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Transfer failed. Data missing.");
                Console.WriteLine("Press any key or close the window for exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }           
        }

        private static DateTime ToShortDateString(DateTime date)
        {
            throw new NotImplementedException();
        }

        private static string GetWeek(int dt)
        {
            if (dt<=7)
            {
                return "First Week";
            }
            if (dt>=8 && dt<15)
            {
                return "Second Week";
            }
            if (dt >= 15 && dt < 22)
            {
                return "Third Week";
            }
            else
            {
                return "Fourth Week";
            }
        }
    }
}
