using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqToExcel;

namespace WindowsFormsApplication1
{
    public partial class ReadFromExcel : Form
    {
        
        public ReadFromExcel()
        {
            InitializeComponent();
            
        }

        private void Init()
        {
            var sqlStatements = new StringBuilder();
            var excel = new ExcelQueryFactory(@"c:\test.xlsx");
            var list = excel.Worksheet<Institute>("Institutes").Select(c => c).ToList();

            foreach (var item in list)
            {
                var redirect = @"<if url=""(.*?){0}(.*)$"" >
        <redirect to=""http://www.ilimudim.co.il{1}""/>                                 
    </if>";
                redirect = string.Format(redirect, item.From.TrimStart('/'), item.To);
                redirect = redirect.Replace("?id", "\\?id");

                sqlStatements.AppendLine(redirect);
            }
            Clipboard.SetText(sqlStatements.ToString());

        }


        private void Init3()
        {
            var sqlStatements = new StringBuilder();
            var excel = new ExcelQueryFactory(@"c:\test.xlsx");
            var list = excel.Worksheet<Institute>("Institutes").Select(c => c).ToList();

            var redirect = @"<if url=""(.*?){0}(.*)$"" >
        <redirect to=""{1}""/>                                 
    </if>";


            foreach (var item in list)
            {
                var fromNew = item.From.Replace("http://ilimudim2.ilimudim.co.il/", "").Replace("&", "&amp;").Replace(".aspx?", ".aspx\\?");
                
                var toNew = item.To.TrimEnd('/');
                if (toNew.Contains("http://www.ilimudim.co.il/admin/content/articles/"))
                    toNew = toNew.Replace("http://www.ilimudim.co.il/admin/content/articles/",
                                          "http://www.ilimudim.co.il/a/").Replace("edit.aspx?id=", "");
                

                sqlStatements.AppendLine(string.Format(redirect, fromNew, toNew));
            }
            Clipboard.SetText(sqlStatements.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Init3();
        }

        private void Init2()
        {
            var sqlStatements = new StringBuilder();
            var excel = new ExcelQueryFactory(@"c:\test.xlsx");
            var list = excel.Worksheet<Category>("Categories").Where(c => c.CategoryFrom!=null).ToList();
            var redirectStatment = new StringBuilder();

            foreach (var category in list)
            {
                var redirect = @"<if url=""(.*?)gui/index/{2}\?categoryid={0}(.*)$"" >
    <redirect to=""http://www.ilimudim.co.il{1}""/>                                 
</if>";

                redirect = redirect.Replace("{2}", getCategoryUrl(category.CategoryTo.TrimEnd('/')));
                sqlStatements.AppendLine(string.Format(redirect, category.CategoryFrom, category.CategoryTo.TrimEnd('/')));
            }

            var restult = sqlStatements.ToString();
        }

        private string getCategoryUrl(string p)
        {
            var retVal = string.Empty;

            if (p.ToLower().Contains("sr"))
                retVal = "searchresults.aspx";
            else if (p.ToLower().Contains("st"))
                retVal = "phase1.aspx";
            else
                retVal = "phase2.aspx";

            return retVal;
        }

       
    }

    public class Category
    {
        public string CategoryFrom { get; set; }
        public string CategoryTo { get; set; }
    }

    public class Institute
    {
        public string From { get; set; }
        public string To{ get; set; }
    }


    public static class extention
    {
        public static string  FixAstrix(this string s)
        {
            var tmp = s;
            if (!string.IsNullOrEmpty(tmp))
            {
                 tmp = tmp.Trim();
                if (tmp.EndsWith("*"))
                    tmp = "*" + tmp.Trim('*');
            }
            return tmp;
        }
    }
}
