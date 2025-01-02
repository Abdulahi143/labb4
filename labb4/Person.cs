namespace labb4;

public class Person
{
    private Gender Gender { get;  set; } 
    private string EyeColor { get;  set; }
    private DateOnly BirthDate { get;  set; }
    private Hair Hair { get;  set; }

    public Person(Gender gender, string eyeColor, DateOnly birthDate, Hair hair)
    {
        Gender = gender;
        EyeColor = eyeColor;
        BirthDate = birthDate;
        Hair = hair;
    }

    public override string ToString()
    {
        return $"Gender: {Gender}, {Hair}, Eye color: {EyeColor}, Date of birth: {BirthDate}";
    }
}

public enum Gender
{
    Female,
    Male
}

public struct Hair
{
    public double HairLength { get; set; }
    public string HairColor { get; set; }

    public override string ToString()
    {
        return $"Hair length: {HairLength}cm, Hair color: {HairColor}";
    }
}


