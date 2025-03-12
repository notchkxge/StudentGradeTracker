using System.Data.SQLite;

public class DataBaseHelper{
    //path to db
    private string _connectionString = "Data Source=Data/students.db;Version=3;";


public void InitializeDatabase(){
        Directory.CreateDirectory("Data");

        if(!File.Exists("Data/students.db")){
            SQLiteConnection.CreateFile("Data/students.db");

            using (var connection = new SQLiteConnection(_connectionString)){

                //establishing connection with db
                connection.Open();

                //creating tables

                var createStudentTable = @"
                    CREATE TABLE Students(
                        StudentId Integer Primary Key AutoIncrement,
                        Name Text Not Null,
                        Email Text
                    );";
                    new SQLiteCommand(createStudentTable, connection).ExecuteNonQuery();
                
                var createCoursesTable = @"
                    CREATE TABLE Courses(
                        CourseId Integer Primary Key AutoIncrement,
                        CourseName Text Not Null
                    );";
                    new SQLiteCommand(createCoursesTable, connection).ExecuteNonQuery();

                var createGradesTable = @"
                    CREATE TABLE Grades(
                        GradeId Integer Primary Key AutoIncrement,
                        StudentId Integer,
                        CourseId Integer,
                        GradeValue Char(1) Not Null,
                        Foreign Key (StudentId) references Students(StudentId),
                        Foreign Key (CourseId) references Courses(CourseId)
                    );";
                    new SQLiteCommand(createGradesTable, connection).ExecuteNonQuery();
            }
        }
    }
}

