using System.Collections.Generic;
using System.Linq;
using WpfApp.EDMX;
using WpfApp.Pages.Forms;

namespace WpfApp.StaticResources
{
    public class ListTitleEmp:List<Title>
    {
        public ListTitleEmp() => this.AddRange(NewEmployee.db.Title.Select(x => x).OrderBy(x => x.Title1).ToArray());
    }
}
