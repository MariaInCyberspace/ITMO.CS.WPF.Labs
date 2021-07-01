using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHello
{
    public class StudentList : ObservableCollection<Student>
    {
        public StudentList()
        {
            Add(new Student("Jeffrey Lawson", true));
            Add(new Student("Silvia Stern", true));
            Add(new Student("Maddox Hawthorn", false));
            Add(new Student("Mercy Thompson", false));
            Add(new Student("Adam Hauptman", true));
        }
    }
}
