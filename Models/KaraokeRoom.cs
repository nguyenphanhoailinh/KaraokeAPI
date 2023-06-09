namespace testAPI.Models
{
    public class KaraokeRoom
    {

        public int Id { get; set; }
        public int IdUser { get; set; }
        public string TenQuan { get; set; }

        public string DiaChi { get; set; }
        public string Img { get; set; }
        public string MoTa { get; set; }
        public int SucChua { get; set; }

        public string MenuId { get; set; }
    }
}
