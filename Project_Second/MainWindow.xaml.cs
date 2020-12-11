using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Common;

namespace Project_Second
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Course cf = new Course();
		public MainWindow()
		{
			InitializeComponent();

			//Create();
			var ctx = new CourseContext();
			// ctx.Courses.Load(); //  *** With this also we can load the data in datagrid*****
			dg.ItemsSource = ctx.Courses.ToList();

			var ctxIn = new CourseContext();
			ctxIn.Instructors.Load();
			dgin.ItemsSource = ctx.Instructors.ToList();
			// dgin.ItemsSource = ctx.Instructors.Local; **** local and Tolist works same ** making list will be easier to iterate over***

		}



		public static void Create()
		{
			string[] instructorNames = { "Ryley Burch", "Janine Houston", "Alena Ortiz", "Ubaid Buck" };

			string[] departments = { "CSC", "MATH", "BIOS", "ENGL" };

			int[] courseNumbers = { 285, 460, 221, 222, 110, 120, 105, 325 };

			int[] refNums = { 12345, 23456, 34567, 45678, 56789, 67890, 78901, 89012 };

			string[] courseName = { "Intro Python ", "Intro to java", "Organic Chemistry", "Education sample", "Econmics I", "Account Intro", "RAID", "Botanical" };

			string[] description = { "Introduction to Python programming", "Java Programming Basic Concept", "Chemistry with Molecules", "Child Education Importance", "Intro to Economic World", "Financial Calculation Account", "App Development", "Tree, Leaves and human life" };

			string[] prereq = { "CSC 110", "CSC 120", "Math 220", "Math 221", "Bio 105", "Bio 110", "English 115", "English 105" };

			string[] status = { "Open", "Open", "Open", "Open", "Open", "Open", "Open", "Open" };
			int[] size = { 12, 10, 13, 14, 15, 16, 17, 18 };
			int[] enrolled = { 09, 9, 9, 9, 9, 9, 9, 9 };
			string[] sem = { "Spring", "Summer", "Fall", "Spring", "Summer", "Fall", "Spring", "Summer" };
			int[] year = { 2020, 2021, 2019, 2020, 2020, 2021, 2019, 2020 };
			string[] section = { "1", "A1", "1C", "B1", "1", "A1", "1C", "B1" };
			int[] credit = { 3, 3, 3, 3, 3, 3, 3, 3 };
			string[] days = { "M", "T", "W", "R", "F", "MW", "MWF", "TR" };
			string[] time = { "11:00 - 11:50", "12:00 - 1:15", "11:00 - 11:50", "12:00 - 1:15", "11:00 - 11:50", "12:00 - 1:15", "11:00 - 11:50", "12:00 - 1:15" };
			string[] location = { "CSC 201", "CSC 222", "BH 263", "BH 201", "SC 100", "SC 213", "BE 201", "BE 263" };


			Instructor[] instructors = new Instructor[4];
			for (int i = 0; i < 4; ++i)
				instructors[i] = new Instructor()
				{
					FirstName = instructorNames[i].Split(new char[] { ' ' })[0],
					LastName = instructorNames[i].Split(new char[] { ' ' })[1],
					Courses = new List<Course>()
				};

			Course[] courses = new Course[8];
			for (int i = 0; i < 8; ++i)
				courses[i] = new Course()
				{
					Department = departments[i / 2],
					//Firstname = instructors[i / 2],
					Inst = instructors[i / 2],
					CourseNumber = courseNumbers[i],
					CourseName = courseName[i],
					Description = description[i],
					Prerequisite = prereq[i],
					Status = status[i],
					ClassSize = size[i],
					Enrolled = enrolled[i],
					Semester = sem[i],
					Year = year[i],
					Id = refNums[i],
					Section = section[i],
					Credit = credit[i],
					Days = days[i],
					Time = time[i],
					Location = location[i],

				};




			using (var ctx = new CourseContext())
			{
				ctx.Instructors.AddRange(instructors);

				ctx.Courses.AddRange(courses);
				ctx.SaveChanges();
			}
		}

		public class Course
		{

			[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
			public int Id { get; set; }
			public string Department { get; set; }
			public int CourseNumber { get; set; }
			public virtual Instructor Inst { get; set; }
			//public virtual Instructor Instructor { get; set; }
			public string CourseName { get; set; }
			public string Description { get; set; }
			public string Prerequisite { get; set; }

			public string Status { get; set; }

			public int ClassSize { get; set; }
			public int Enrolled { get; set; }
			public string Semester { get; set; }
			public int Year { get; set; }
			public string Section { get; set; }
			public int Credit { get; set; }
			public string Days { get; set; }
			public String Time { get; set; }
			public string Location { get; set; }


			public override string ToString()
			{
				return string.Format("{0}", Id);
			}


		}


		public class Instructor
		{
			public int Id { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public virtual List<Course> Courses { get; set; }

			public override string ToString()
			{
				return string.Format("{0} {1}", FirstName, LastName);
			}
		}
		public class CourseContext : DbContext
		{
			public CourseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
				@"AttachDbFilename=C:\Users\KAILASH DHAKAL\OneDrive\Documents\Registrations.mdf;Integrated Security=True;Connect Timeout=30")
			{ }
			//(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
			//@"AttachDbFilename=C:\Users\KAILASH DHAKAL\OneDrive\Documents\Registrations.mdf;Integrated Security=True;Connect Timeout=30")



			public DbSet<Course> Courses { get; set; }
			public DbSet<Instructor> Instructors { get; set; }


		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			CourseForm cf = new CourseForm();
			cf.Show();
			this.Close();
		}

		private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{

			try
			{
				//DataGrid dg = (DataGrid)sender;
				CourseForm fc = new CourseForm();

				//c2 holds the ilist from the selecteed items of the datagrid.
				Course c2 = (Course)dg.SelectedItem;

				fc.txtId.Text = c2.Id.ToString();
				fc.txtDep.Text = c2.Department;
				fc.txtName.Text = c2.CourseName;
				fc.txtNumber.Text = c2.CourseNumber.ToString();
				fc.txtDesc.Text = c2.Description;
				fc.txtPre.Text = c2.Prerequisite;
				fc.txtInst.Text = c2.Inst.FirstName;
				fc.txtInstLast.Text = c2.Inst.LastName;

				fc.txtStatus.Text = c2.Status.ToString();
				fc.txtSize.Text = c2.ClassSize.ToString();
				fc.txtEnrolled.Text = c2.Enrolled.ToString();
				fc.txtSem.Text = c2.Semester.ToString();
				fc.txtYear.Text = c2.Year.ToString();

				fc.txtSection.Text = c2.Section.ToString();
				fc.txtCredit.Text = c2.Credit.ToString();
				fc.cBox.Text = c2.Days.ToString();
				fc.txtTime.Text = c2.Time.ToString();
				fc.txtLoacation.Text = c2.Location.ToString();

				fc.Show();
				this.Close();
			}
			catch (Exception err2)
			{
				MessageBox.Show(err2.Message);
			}


		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			InstructorForm fi = new InstructorForm();
			fi.Show();
			this.Close();
		}


		private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
		{

			CourseContext ctx = new CourseContext();

			dg.ItemsSource = ctx.Courses.Where(x => x.Department.Contains(txtSearch.Text) || x.CourseNumber.ToString().Contains(txtSearch.Text) || x.Inst.FirstName.Contains(txtSearch.Text) || x.Inst.LastName.Contains(txtSearch.Text) || x.Year.ToString().Contains(txtSearch.Text) || x.Semester.ToString().Contains(txtSearch.Text)).ToList();


			//dg.ItemsSource = ctx.Courses.Where(x => x.Department.Contains(txtSearch.Text) || x.CourseNumber.ToString().Contains(txtSearch.Text) || x.Instructor.FirstName.Contains(txtSearch.Text) || x.Instructor.LastName.Contains(txtSearch.Text) || x.Year.ToString().Contains(txtSearch.Text) || x.Semester.ToString().Contains(txtSearch.Text)).ToList();



		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			// Delete the selected row out of datagrid ********************

			Course c2 = (Course)dg.SelectedItem;

			CourseContext ctx = new CourseContext();

			var Course = ctx.Courses.First(c => c.Id == c2.Id);
			ctx.Courses.Remove(Course);
			ctx.SaveChanges();

			MessageBox.Show("Data Deleted Successfully !!!!!");

			// This helps to load the data after the deleting the selected row.*********
			dg.ItemsSource = ctx.Courses.ToList();
			var ctxIn = new CourseContext();

			ctxIn.Instructors.Load();
			dgin.ItemsSource = ctx.Instructors.ToList();


		}

		private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
		{

			try
			{
				// Trying to get to the course form to modify the data *************
				if (e.Key == Key.Enter)
				{
					CourseForm fc = new CourseForm();

					Course c2 = (Course)dg.CurrentItem;

					fc.txtId.Text = c2.Id.ToString();
					fc.txtDep.Text = c2.Department;
					fc.txtName.Text = c2.CourseName;
					fc.txtNumber.Text = c2.CourseNumber.ToString();
					fc.txtDesc.Text = c2.Description;
					fc.txtPre.Text = c2.Prerequisite;
					fc.txtInst.Text = c2.Inst.FirstName;
					fc.txtInstLast.Text = c2.Inst.LastName;

					fc.txtStatus.Text = c2.Status.ToString();
					fc.txtSize.Text = c2.ClassSize.ToString();
					fc.txtEnrolled.Text = c2.Enrolled.ToString();
					fc.txtSem.Text = c2.Semester.ToString();
					fc.txtYear.Text = c2.Year.ToString();

					fc.txtSection.Text = c2.Section.ToString();
					fc.txtCredit.Text = c2.Credit.ToString();
					fc.cBox.Text = c2.Days.ToString();
					fc.txtTime.Text = c2.Time.ToString();
					fc.txtLoacation.Text = c2.Location.ToString();

					fc.Show();
					this.Close();
				}
			}
			catch (Exception err2)
			{
				MessageBox.Show(err2.Message);
			}


		}
	}
}



