using System.Collections.Generic;

namespace WebApp.DAL.Entities
{
    public class CertificateGroup
    {
        public int CertificateGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Certificate> Dishes { get; set; }
    }
}
