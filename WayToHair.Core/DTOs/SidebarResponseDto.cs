namespace WayToHair.Core.DTOs
{
    public class SidebarResponseDto
    {
        public long Id { get; set; } 
        public string? Label { get; set; }
        public string? Href { get; set; }
        public ChildSideBarResponseDto ChildSideBarResponseDto { get; set; }
    }

    public class ChildSideBarResponseDto
    {
        public string? Label { get; set; }
        public string? Href { get; set; }
        public string? SubLabel { get; set; }
    }
}

