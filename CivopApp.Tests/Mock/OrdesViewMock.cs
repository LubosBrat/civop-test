using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CivopApp.Models;
using CivopApp.Views;

namespace CivopApp.Tests.Mock
{
    public class OrdesViewMock : PageMockBase, IOrdersView
    {
        public ObservableCollection<OrderViewModel> Data { get; set; }
    }
}
