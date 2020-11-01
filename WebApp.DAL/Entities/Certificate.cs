namespace WebApp.DAL.Entities
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        public string CertificateName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } 
        public string Image { get; set; } 

        //группа
        public int CertificateGroupId { get; set; }
        public CertificateGroup Group { get; set; }
    }
}
