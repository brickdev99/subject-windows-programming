using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPR.Project.QLSV
{
    public static class Globals
    {
        static int globalUserId;
        public static void setGlobalUserId(int userID)
        {
            GlobalUserId = userID;
        }
        public static int GlobalUserId
        {
            get => globalUserId;
            private set => globalUserId = value;
        }
    }
}
