using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva
{
    public static class Settings
    {
        static Settings()
        {
            DotNetEnv.Env.Load();
        }

        public static string CONNECT_STRING => DotNetEnv.Env.GetString("CONNECT_STRING");
    }
}
