using System.Text.Json.Serialization;

namespace WebAppBlazor.Data
{
    public class CertificateListViewModel
    {
        [JsonPropertyName("certificateId")]
        public int CertificateId { get; set; }
        [JsonPropertyName("certificateName")]
        public string CertificateName { get; set; }
    }
    public class CertificateDetailsViewModel
    {
        [JsonPropertyName("certificateName")]
        public string CertificateName { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("price")]
        public int Price { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }

}
