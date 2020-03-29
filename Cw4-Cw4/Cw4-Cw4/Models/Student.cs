namespace Cw4_Cw4.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string IndexNumber { get; set; }

        public override string ToString()
        {
            return IdStudent + ", " + FirstName + ", " + Lastname + ", " + IndexNumber;
        }
    }
    
}