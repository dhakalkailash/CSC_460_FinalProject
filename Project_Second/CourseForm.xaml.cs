using Google.Apis.Analytics.v3.Data;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
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
	/// Interaction logic for CourseForm.xaml
	/// </summary>
	public partial class CourseForm : Window
	{
		Course cf = new Course();
		public CourseForm()
		{

			InitializeComponent();
			cBox.ItemsSource = Enum.GetValues(typeof(week));

		}
		public enum week
		{
			M, T, W, R, F, MW, MWF, TR
		}
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Its the combo Box ********************
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// Add new button**********
			try
			{


				cf.Id = Convert.ToInt32(txtId.Text);
				cf.Department = txtDep.Text;
				cf.CourseName = txtName.Text;
				cf.CourseNumber = Convert.ToInt32(txtNumber.Text);
				cf.Description = txtDesc.Text;
				cf.Prerequisite = txtPre.Text;
				cf.Status = txtStatus.Text;
				cf.ClassSize = Convert.ToInt32(txtSize.Text);
				cf.Enrolled = Convert.ToInt32(txtEnrolled.Text);
				cf.Semester = txtSem.Text;
				cf.Year = Convert.ToInt32(txtYear.Text);
				cf.Section = txtSection.Text;
				cf.Credit = Convert.ToInt32(txtCredit.Text);
				cf.Days = cBox.Text;
				cf.Time = txtTime.Text;
				cf.Location = txtLoacation.Text;

				CourseContext ctx = new CourseContext();


				var insta = ctx.Instructors.SingleOrDefault(x => x.FirstName == txtInst.Text && x.LastName == txtInstLast.Text);

				if (insta != null)
				{
					cf.Inst = (Instructor)insta;
					MessageBox.Show("Sucessfully New course added");

				}
				else
				{
					Instructor instruct = new Instructor();
					instruct.FirstName = txtInst.Text;
					instruct.LastName = txtInstLast.Text;
					MessageBox.Show("Sucessfully New Instructor Created and New course is added");
					ctx.Instructors.Add(instruct);
					cf.Inst = instruct;

				}
				ctx.Courses.Add(cf);
				ctx.SaveChanges();
				MessageBox.Show("Data successdully saved ");
				MainWindow m = new MainWindow();
				m.Show();
				this.Close();
			}
			catch (Exception err2)
			{
				MessageBox.Show(err2.Message);
			}


		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			// ****** Update Button *******

			CourseContext ctx = new CourseContext();
			int courseID = Convert.ToInt32(txtId.Text);

			Course course = ctx.Courses.SingleOrDefault(x => x.Id == courseID);

			if (course != null)
			{
				course.Id = Convert.ToInt32(txtId.Text);

				course.Department = txtDep.Text;
				course.CourseName = txtName.Text;
				course.CourseNumber = Convert.ToInt32(txtNumber.Text);
				course.Description = txtDesc.Text;
				course.Prerequisite = txtPre.Text;
				course.Status = txtStatus.Text;
				course.ClassSize = Convert.ToInt32(txtSize.Text);
				course.Enrolled = Convert.ToInt32(txtEnrolled.Text);
				course.Semester = txtSem.Text;
				course.Year = Convert.ToInt32(txtYear.Text);
				course.Section = txtSection.Text;
				course.Credit = Convert.ToInt32(txtCredit.Text);
				course.Days = cBox.Text;
				course.Time = txtTime.Text;
				course.Location = txtLoacation.Text;
				course.Inst.FirstName = txtInst.Text;
				course.Inst.LastName = txtInstLast.Text;

			}
			try
			{
				ctx.SaveChanges();
				MessageBox.Show("Data successdully updated ");
				MainWindow m = new MainWindow();
				m.Show();
				this.Close();
			}
			catch (Exception err2)
			{
				MessageBox.Show(err2.Message);
			}


		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			// TO Do ******************* DELETE 

			MessageBox.Show("It will take you back to MainWindow ");
			MainWindow m = new MainWindow();
			m.Show();
			this.Close();
		}
	}
}


