using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExperaments
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var r1 = new FilterR1();
        //    var r2 = new FilterR2();
            
        //    var f1 = new FilterB();

        //    var filtersList = new List<IFilter>(){r1, r2, f1};

        //    foreach (var filter in filtersList)
        //    {
        //        filter.Init();
        //    }
        //}
    }

    public abstract class BaseFilter : IFilter
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }

        public void Init()
        {
        }
    }

    public abstract class RequireFilter : BaseFilter
    {
        public virtual void Init()
        {
           //RequireFilter implment
            int x;
        }
    }


    public class FilterR1 : RequireFilter
    {
       
    }

    public class FilterR2 : RequireFilter
    {
        
    }

    public class FilterB : BaseFilter
    {
        public void Init()
        {
            throw new NotImplementedException();
        }
    }

    public interface IFilter
    {
        void Init();
    }
}
