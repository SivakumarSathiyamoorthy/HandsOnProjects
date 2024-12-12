using LiskovSubstitutionPrinciple;


Student stu = new Student()
{
    Name = "Appu",
    Tamil = 99,
    Maths = 90,
    Science = 89

};


OverallGrade obj;
obj= new OverallGrade();
string value =obj.GetGrade(stu);
Console.WriteLine(value);

obj = new EngineeringGrade();
value = obj.GetGrade(stu);
Console.WriteLine(value);
