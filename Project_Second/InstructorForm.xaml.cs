using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Project_Second.MainWindow;

namespace Project_Second
{
	/// <summary>
	/// Interaction logic for InstructorForm.xaml
	/// </summary>
	public partial class InstructorForm : Window
	{
		//InstructorForm fm = new InstructorForm();
		Instructor Instr = new Instructor();
		public InstructorForm()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Instr.Id = Convert.ToInt32(txtId.Text);
			Instr.FirstName = txtfirst.Text;
			Instr.LastName = txtLast.Text;

			//Instr.Courses = txtCourse.Text;
			using (CourseContext ctx = new CourseContext())
			{
				ctx.Instructors.Add(Instr);
				ctx.SaveChanges();
			}
			MessageBox.Show("Data successdully saved ");
			MainWindow m = new MainWindow();
			m.Show();
			this.Close();

		}
	}
}
