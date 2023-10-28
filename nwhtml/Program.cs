using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace nwhtml{
 class Path {
     public string dsktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
     public string fldrCaller = Environment.CurrentDirectory;
     public string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
     public string userPrograms = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Programs";
     public string appfldr = AppDomain.CurrentDomain.BaseDirectory;
 } 
 class Program{
static void openVscode() {
Path path = new Path();
System.Diagnostics.Process.Start(path.userPrograms + "\\Microsoft VS Code\\code.exe", "\"" + path.fldrCaller + "\"");
}
static void addBootStrap() {
    Path path = new Path();

    string dir = @"bootstrap";
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }

    File.Copy(path.appfldr + "nw\\bootstrap\\bootstrap.min.css", path.fldrCaller + "\\bootstrap\\bootstrap.min.css");
    File.Copy(path.appfldr + "nw\\bootstrap\\bootstrap.min.css", path.fldrCaller + "\\bootstrap\\bootstrap.min.js");
    File.Copy(path.appfldr + "nw\\bootstrap\\bootstrap.min.css", path.fldrCaller + "\\bootstrap\\bootstrap.bundle.min.js");
}

static void addFontawesome()
{
       
    string fntawesomeLink = "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css\" integrity=\"sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==\"  crossorigin=\"anonymous\" referrerpolicy=\"no-referrer\" />";
    Console.WriteLine(fntawesomeLink);
}
    static void Main(string[] args){
  
        Path path = new Path();


   



        if (args.Length > 0 && args[0] == "vs") {
            openVscode();
        }

        if (args.Length > 0 && args[0] == "bs"){
            addBootStrap();
        }



        if (args.Length > 0 && args[0] == "font-awesome")
        {
            addFontawesome();
        }



        

        //بسم الله الرحمن الرحيم
         if (args.Length > 0 && args[0] == "html") {
            
                //argument folder name
                string fldrName;
                if (args.Length > 1 && args[1].Length > 0){
                     //set name to fldr
                    fldrName = args[1].Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace(">", "").Replace("|", "").Replace("\"", "").Replace("?", "");
                }else{
                    fldrName = "New html";
                }

                
                string fldrPath;
                if (path.fldrCaller == path.userProfile){
                    fldrPath = path.dsktop + "\\" + fldrName;
                }else{
                    fldrPath = path.fldrCaller + "\\" + fldrName;
                }




                fldrName = folderName(fldrPath, 2);
                Directory.CreateDirectory(fldrName);

                //write html5
                using (StreamWriter html = new StreamWriter(fldrName + "\\index.html")){
                    html.Write("<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>Document</title>\n    <link rel=\"stylesheet\" href=\"style.css\">\n</head>\n<body>\n\n\n<script src=\"script.js\"></script>\n</body>\n</html>");
                }

                //write css / js
                FileStream style = File.Create(fldrName + "\\style.css");
                FileStream script = File.Create(fldrName + "\\script.js");

    

                
            }


         
  
        }


        static string folderName(string path, int x)
        {

       
            if (Directory.Exists(path)) //if already there's folder created before
            {
                path = path.Replace(" (" + (x - 1) + ")", ""); //remove new folder(x)
                return folderName(path + " (" + x + ")", x + 1);//add new folder(x)
            }

            return path;

        }



    }
}
