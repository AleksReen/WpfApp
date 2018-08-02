using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.EDMX;
using WpfApp.Pages.Forms;

namespace WpfApp.StaticResources
{
    class ListTitleEmpEdit : List<Title>
    {  
        public ListTitleEmpEdit() => this.AddRange(EditEmployeer.db.Title.Select(x => x).OrderBy(x => x.Title1).ToArray());
    }
}
