namespace HcDentalClinic.Layout.Shared.Data;


public class ClinicalCase
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string[] Paragraphs { get; set; } = [];
    public ClinicalCaseImage[] Images { get; set; } = [];
}

public class ClinicalCaseImage
{
    public string Src { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
}
