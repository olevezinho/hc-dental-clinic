namespace HcDentalClinic.Layout.Shared.Data;

public class TeamMember
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Position { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> Qualifications { get; set; } = new();
    public List<string> Specialties { get; set; } = new();
    public string FullBio { get; set; } = string.Empty;

    public string PositionText => string.Join(" | ", Position);

    public string QualificationsText => string.Join(" | ", Qualifications);
}