using System; // Added line
using System.Collections.Generic; //Added Line

public class School {
  public class Student
  {
    private String studentId;//, cityId, courseId; This parameters not neeed in this class
    public String getStudentId() {
      return studentId;
    }
    /* This function not needed here, can be received form City class
    public String getCityId() {
      return cityId;
    }
    */
    /* This function not needed here, can be received form Course class
    public String getCourseId() {
      return courseId;
    }
    */
    
    private int mathGrade;
    public int MathGrade
    {
        get
        {
          return this.mathGrade;
        }
        set
        {
          this.mathGrade = value;
        }
    }
  }
  public class City
  {
    private String cityId, cityName;
    public String getCityId() {
      return cityId;
    }
    public String getCityName() {
      return cityName;
    }
  }
  public class Course
  {
    private String courseId, courseName;
    public String getCourseId()
    {
      return courseId;
    }
    public String getCourseName()
    {
      return courseName;
    }
  }

  // This class makes retrieves data synchronous from an external Database
  // This class CANNOT be modified
  // Database invokations take about 1 second

  /* If each function takes a second because it goes to the database, 
     I would import the entire returned row. For example, receiving the name of the course 
     will be received from an object if we have already received the ID of the course
  */
  public class Database {
    public Database(String name)
    {
      
    }
    public Student getStudentById(String id)
    {
      return new Student(); //Added for compilation
    }
    public List < Student > getStudentsByCity(String cityId)
    {
      return new List<Student>(); //Added for compilation
    }
    public List < Student > getStudentsByCourse(String courseId)
    {
      return new List<Student>(); //Added for compilation
    }
    public City getCityById(String cityId)
    {
      return new City(); //Added for compilation
    }
    public City getCityByName(String cityName)
    {
      return new City(); //Added for compilation
    }
    public Course getCourseById(String courseId) {
      return new Course(); //Added for compilation
    }
    public Course getCourseByName(String courseName) {
      return new Course(); //Added for compilation
    }
    // gets the grade the student got in a specific course
    public int getStudentGrade(String studentId, String courseId) {
      return -1; //Added for compilation
    }
  }
  // School continues in next page...

  // Continuation of class School
  public static int getAverageMathematicGradesOfHertzeliaStudents()
  {
    Database db = new Database("DbName"); //Added db name to constructor
    Course mathematics = db.getCourseByName("mathematics");
    String mathematicsId = mathematics.getCourseId(); //Changed line. Use method, parameter is private
    List < Student > mathematicsStudents = db.getStudentsByCourse(mathematicsId);
	/* 	For better performance, I would think replace the above line to fetch also the student math grade
		foreach(Student student in mathematicsStudents) //and this will replace the foreach block below
		{
			grades.Add(student.MathGrade)
		}
	*/
    List < int > grades = new List < int > ();
    foreach(Student student in mathematicsStudents)
	{
      //City hertzelia = db.getCityByName("Hertzelia"); //No need for calculate the average, a waste of calling to the database
      //String cityId = hertzelia.getCityId(); //No need for calculate the average
      mathematicsId = mathematics.getCourseId();
      int grade = db.getStudentGrade(student.getStudentId(), mathematicsId); //Changed line. First paramter change to get the student id
      grades.Add(grade);
    }

    int gradesCount = 0;
    int sum = 0;
    foreach(int grade in grades) {
      gradesCount = gradesCount + 1;
      sum = sum + grade;
    }
    if(gradesCount  == 0) return 0; //Added line. For not dividing by zero
      
    int average = sum / gradesCount;
    
    return average;
  }
  public static void Main() {
    int averageMathematicGradesOfHertzeliaStudents =
      getAverageMathematicGradesOfHertzeliaStudents();
    Console.Write("averageMathematicGradesOfHertzeliaStudentss: {0}", averageMathematicGradesOfHertzeliaStudents);
    Console.WriteLine();
  }
}