using MauiSqliteDB.DataAccess;
using MauiSqliteDB.Models;

namespace MauiSqliteDB
{
    public partial class MainPage : ContentPage
    {
        private int _id = 0;
        private readonly AppDbContext _context;

        public MainPage(AppDbContext context)
        {
            _context = context;

            InitializeComponent();

            lvStudent.ItemsSource = _context.Students.ToList();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtClass.Text))
                return;

            if (btn.Text.Equals("Save"))
            {
                _id = _context.Students.Count() + 1;

                StudentDT studentDB = new StudentDT() { Id = _id, Name = txtName.Text, Class = txtClass.Text };

                _context.Students.Add(studentDB);
            }
            else
            {
                StudentDT student = _context.Students.SingleOrDefault(s => s.Id == _id);
                if (student != null)
                {
                    student.Name = txtName.Text;
                    student.Class = txtClass.Text;
                    btn.Text = "Save";
                }
            }

            _context.SaveChanges();
            lvStudent.ItemsSource = _context.Students.ToList();
            txtName.Text = txtClass.Text = String.Empty;
            txtName.Focus();
        }

        private void lvStudent_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var selectedStudent = (StudentDT)e.Item;

            _id = selectedStudent.Id;
            txtName.Text = selectedStudent.Name;
            txtClass.Text = selectedStudent.Class;
            btn.Text = "Update";

            lvStudent.SelectedItem = null;
        }
    }

}
