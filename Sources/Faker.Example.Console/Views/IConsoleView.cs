using Faking.Example.Console.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faking.Example.Console.Views
{
    public interface IConsoleView<VM> where VM : ViewModelBase
    {
        VM ViewModel { get; }

        String Execute(String command);

        String Print();
    }
}
