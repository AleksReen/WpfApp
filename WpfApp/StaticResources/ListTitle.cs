using System.Collections.Generic;
using System.Linq;
using WpfApp.EDMX;
using WpfApp.Pages;

namespace WpfApp.StaticResources
{
    public class ListTitle:List<Title>
    {
        public ListTitle() => this.AddRange(Employees.db.Title.Select(x => x).OrderBy(x => x.Title1).ToArray());
    }
}
