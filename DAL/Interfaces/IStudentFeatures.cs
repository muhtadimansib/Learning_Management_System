using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentFeatures
    {
        List<Enrollment> SeeEnrollments(int id);
        List<object> Dashoard(int id);
        void ExportStudentsToPdf(string filePath);

        List<Student> SearchByName(string name);

    }
}
