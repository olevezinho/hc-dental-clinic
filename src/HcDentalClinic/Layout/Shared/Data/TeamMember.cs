namespace HcDentalClinic.Layout.Shared.Data;

public class TeamMember
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Qualifications { get; set; } = string.Empty;
    public List<string> Specialties { get; set; } = new();
    public string FullBio { get; set; } = string.Empty;
}