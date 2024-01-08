using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolio.API.Entities.PersonalInfo;

[Table(name: "personal_information")]
public class PersonalInformation
{
    [Key]
    public int personal_info_id { get; set; }
    public required string first_name { get; set; }
    public required string last_name { get; set; }
    public DateTime date_of_birth { get; set; }
    public required string gender { get; set; }
    public required string ethnicity { get; set; }
}
