using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List <string> tasknames = new List <string>();
        private List<int> prioirtyorder = new List<int>();
        private List<int> dateorder = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //tasknamesdisplay.Items.Add(taskname.Text);
            //prioirties.Items.Add(priority.Text);
            //dates.Items.Add(duedate.Text);
            tasknamesdisplay.Items.Clear();
            prioirties.Items.Clear();
            dates.Items.Clear();

            if (tasknames.Count == 0)
            {
                tasknames.Add(taskname.Text);
                prioirtyorder.Add(int.Parse(priority.Text));
                dateorder.Add(int.Parse(duedate.Text));
            }
            else {
                int insert = dateorder.Count() - SortItems(dateorder, int.Parse(duedate.Text), dateorder.Count()-1,prioirtyorder, int.Parse(priority.Text));

                tasknames.Insert(insert, taskname.Text);
                prioirtyorder.Insert(insert, int.Parse(priority.Text));
                dateorder.Insert(insert, int.Parse(duedate.Text));

            }
            foreach (string task in tasknames) 
            {
                tasknamesdisplay.Items.Add(task);
            }

            foreach (int prioirty in prioirtyorder)
            {
                prioirties.Items.Add(prioirty);
            }

            foreach (int date in dateorder)
            {
                dates.Items.Add(date);
            }

            taskname.Clear();
            priority.Clear();
            duedate.Clear();
        }
        private int SortItems(List<int> dateorder, int additem, int start, List<int> prioirites, int addprioirty) {
            if (dateorder[start] > additem)
            {
                if (start == 0)
                {
                    return 1;
                }
                else
                {
                    return SortItems(dateorder, additem, start - 1, prioirites, addprioirty) + 1;
                }
            }
            else if (dateorder[start] == additem) {
                if (prioirites[start] < addprioirty)
                {
                    if (start == 0)
                    {
                        return 1;    
                    }
                    else {
                        return SortItems(dateorder, additem, start - 1, prioirites, addprioirty) + 1;
                    }
                    }
                else {
                    return 0; 
                }
            }
            else
            {
                return 0;
            }
        }
    }
}