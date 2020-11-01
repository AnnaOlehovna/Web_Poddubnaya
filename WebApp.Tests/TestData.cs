using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Data;
using WebApp.DAL.Entities;

namespace WebApp.Tests
{
    public class TestData
    {
        public static List<Certificate> GetCertificatesList()
        {
            return new List<Certificate>
        {
            new Certificate{ CertificateId=1, CertificateGroupId =1},
            new Certificate{ CertificateId=2, CertificateGroupId =1},
            new Certificate{ CertificateId=3, CertificateGroupId =2},
            new Certificate{ CertificateId=4, CertificateGroupId =2},
            new Certificate{ CertificateId=5, CertificateGroupId =3}
        };
        }

        public static void FillContext(ApplicationDbContext context)
        {
            context.CertificateGroups.Add(new CertificateGroup
            { GroupName = "fake group" });
            context.AddRange(new List<Certificate>{
            new Certificate { CertificateId = 1, CertificateGroupId = 1 },
            new Certificate { CertificateId = 2, CertificateGroupId = 1 },
            new Certificate { CertificateId = 3, CertificateGroupId = 2 },
            new Certificate { CertificateId = 4, CertificateGroupId = 2 },
            new Certificate { CertificateId = 5, CertificateGroupId = 3 }
            });
            context.SaveChanges();
        }

        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }
    }
}
