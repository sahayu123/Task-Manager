using System.Linq;
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
        // Lists of tasks, proitities, dateorder
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

            // Checking that user inputs were valid 
            if (taskname.Text != "" && taskname.Text.All(char.IsLetter))
            {
                if (priority.Text !="" && (int.TryParse(priority.Text, out int number)) && number >=1 && number <=5)
                {
                    if (duedate.Text !="" && int.TryParse(duedate.Text, out int number2) && number2>=0)
                    {
                        // Clearing the Items on Display 

                        tasknamesdisplay.Items.Clear();
                        prioirties.Items.Clear();
                        dates.Items.Clear();

                        // adds initial primary items to list 
                        if (tasknames.Count == 0)
                        {

                            tasknames.Add(taskname.Text);
                            prioirtyorder.Add(int.Parse(priority.Text));
                            dateorder.Add(int.Parse(duedate.Text));

                        }
                        else
                        {
                            // Gets the index that the items have to be inserted into
                            int insert = dateorder.Count() - SortItems(dateorder, int.Parse(duedate.Text), dateorder.Count() - 1, prioirtyorder, int.Parse(priority.Text));

                            // Inserts items into the list
                            tasknames.Insert(insert, taskname.Text);
                            prioirtyorder.Insert(insert, int.Parse(priority.Text));
                            dateorder.Insert(insert, int.Parse(duedate.Text));

                        }
                        // Adding from the list to the GUI 
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

                        // Clearing the Input Boxes 
                        taskname.Clear();
                        priority.Clear();
                        duedate.Clear();
                    }
                }
            }
        }
        // Method Returns the amount of indexes that u need to mvove to the right of
        private int SortItems(List<int> dateorder, int additem, int start, List<int> prioirites, int addprioirty) {
            // Check if the item that needs to be added is less than the item thats there 
            if (dateorder[start] > additem)
            {
                // If its the first item reutn 1
                if (start == 0)
                {
                    return 1;
                }
                else
                // If it isnt the first item, then recurse through the fucntion again and check the number to the right 
                {
                    return SortItems(dateorder, additem, start - 1, prioirites, addprioirty) + 1;
                }
            }
            // Checks if the valeues are equal, upon which it will check the priority values 
            else if (dateorder[start] == additem) {

                // Checkks if  the item that needs to be added is greter than the one thats there 
                if (prioirites[start] < addprioirty)
                {
                    // if its the first elemnt return 1 
                    if (start == 0)
                    {
                        return 1;    
                    }
                    else {
                    // recursing through the fuciton again and checking the number to the right 
                        return SortItems(dateorder, additem, start - 1, prioirites, addprioirty) + 1;
                    }
                    }
                // returning 0 if number is not greater 
                else {

                    return 0; 
                }
            }
            // returns 0 if number is not less than
            else
            {
                return 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (removetask.Text != "" && removetask.Text.All(char.IsLetter))
            {
                int index = tasknames.IndexOf(removetask.Text); 

                    tasknames.RemoveAt(index);
                    prioirtyorder.RemoveAt(index);
                    dateorder.RemoveAt(index);

                    tasknamesdisplay.Items.Clear();
                    prioirties.Items.Clear();
                    dates.Items.Clear();

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

                    removetask.Clear(); 

                }



            }


        }
    }
