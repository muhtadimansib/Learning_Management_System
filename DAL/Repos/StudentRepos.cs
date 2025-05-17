using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace DAL.Repos
{
    internal class StudentRepos : Repo, IRepo<Student, int, Student>,IStudentFeatures
    {
        public Student Create(Student obj)
        {
            db.Students.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public List<object> Dashoard(int id)
        {
            
            var student = db.Students.Find(id);
            if (student == null) return new List<object>(); 

            
            var enrollments = db.Enrollments.Where(e => e.StudentId == id).ToList();
            var courses = db.Courses.ToList();
            List<Course> enrolledcourses = new List<Course>();
            
            foreach (Enrollment e in enrollments)
            {
                foreach(Course c in courses)
                {
                    if(e.CourseId==c.Id)
                    {
                        enrolledcourses.Add(c);
                    }
                }
            }
            

            var result = new List<object>
            {
                
                new Dictionary<string, object>
                {
                    { "StudentId", student.StudentId },
                    { "Name", student.Name },
                    { "Email", student.Email },
                    { "PhoneNumber", student.PhoneNumber },
                    { "CGPA", student.CGPA }
                },

                new Dictionary<string, object>
                {
                    { "Enrollment", enrollments
                        .Select(e => new Dictionary<string, object>
                        {
                            {"Enrollment ID", e.EnrollId },
                            { "Enrollment Date", e.EnrollmentDate },
                            { "Progress", e.Progress },
                            { "Course ID", e.CourseId },
                            { "Course Name", db.Courses.Find(e.CourseId).CourseName },
                            { "Course Instructor",db.Courses.Find(e.CourseId).InstructorName },
                            { "Course Duration",db.Courses.Find(e.CourseId).Duration}

                        })
                        .ToList()
                    }
                },

                

            };

            return result;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Students.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public void ExportStudentsToPdf(string filePath)
        {
            var students = db.Students.ToList();

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);

                pdfDoc.Open();
                pdfDoc.Add(new Paragraph("List of Students\n\n"));

                PdfPTable table = new PdfPTable(5); // 5 columns: ID, Name, Email, Phone, CGPA
                table.AddCell("Student ID");
                table.AddCell("Name");
                table.AddCell("Email");
                table.AddCell("Phone Number");
                table.AddCell("CGPA");

                foreach (var student in students)
                {
                    table.AddCell(student.StudentId.ToString());
                    table.AddCell(student.Name);
                    table.AddCell(student.Email);
                    table.AddCell(student.PhoneNumber);
                    table.AddCell(student.CGPA.ToString("F2"));
                }

                pdfDoc.Add(table);
                pdfDoc.Close();
                writer.Close();
            }
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public List<Student> SearchByName(string name)
        {
            return db.Students.Where(s => s.Name.Contains(name)).ToList(); 
        }

        public List<Enrollment> SeeEnrollments(int id)
        {
            return db.Enrollments.Where(e => e.StudentId==id).ToList();

        }

        public Student Update(Student obj)
        {
            var ex = Get(obj.StudentId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return ex;
        }

       

    }
}
