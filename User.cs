namespace backend_crud;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public Int64 Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public int Gender { get; set; }

    public DateTime BirthDate { get; set; }
}
