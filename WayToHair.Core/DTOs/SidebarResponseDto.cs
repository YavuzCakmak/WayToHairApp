namespace WayToHair.Core.DTOs
{
    public class SidebarResponseDto
    {
        public long Id { get; set; } 
        public string? Label { get; set; }
        public string? Href { get; set; }
        public int Sequence { get; set; }
        public List<ChildSideBarResponseDto> ChildSideBarResponseDto { get; set; } = new List<ChildSideBarResponseDto>();
    }

    public class ChildSideBarResponseDto
    {
        public string? Label { get; set; }
        public string? Href { get; set; }
    }
}

