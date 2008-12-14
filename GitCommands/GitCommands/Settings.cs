﻿using System;
using System.Collections.Generic;

using System.Text;

namespace GitCommands
{
    public class Settings
    {
        public static string GitDir 
        {
            get
            {
                return "";
                //return @"c:\msysgit\bin\";
            }
        }

        private static string workingdir;
        public static string WorkingDir
        {
            get
            {
                return workingdir;
            }
            set
            {
                workingdir = GitCommands.FindGitWorkingDir(value);
            }
        }

        public static string GitLog { get; set; }
    }
}
