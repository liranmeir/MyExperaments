using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExperaments
{
    public class MySingletone
    {
        private static object locker;
        private static volatile  MySingletone instance;

        private MySingletone()
        {
        }

        public MySingletone Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance ==null)
                            instance = new MySingletone();
                    }
                }
                
                return instance;
            }
        }

        static void Main(string[] args)
        {
            
        }
    }

    public class MySingletone2
    {
        private static object locker;
        private static volatile MySingletone2 instance;

        public MySingletone2 Instanse { 
            get
            {
                
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new MySingletone2();
                        }
                    }
                }
                return instance;
            }
        }

    }
}
