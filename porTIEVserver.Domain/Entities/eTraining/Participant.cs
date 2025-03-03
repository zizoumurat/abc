using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using porTIEVserver.Domain.Abstractions;
using porTIEVserver.Domain.Entities.Admin.AppSets;

namespace porTIEVserver.Domain.Entities.eTraining
{
    public sealed class Participant : Entity
    {
        public string       Code            { get; set; } = string.Empty;       /* TCK NO           */
        public string       FirstName       { get; set; } = string.Empty;       /* Adı              */
        public string       LastName        { get; set; } = string.Empty;       /* Soyadı           */
        public string       FullName => string.Join(" ", FirstName, LastName);  /* Adı ve Soyadı    */
        public string       Phone1          { get; set; } = string.Empty;       /* Telefon 1        */
        public string       Phone2          { get; set; } = string.Empty;       /* Telefon 2        */
        public Course?   TrainType       { get; set; }                       /* Tür : T1,T2,Y1,Y2      */
        public bool         IsCandidate     { get; set; }                       /* Ön Kayıtlı */
        public Classroom?  TraineRoom      { get; set; }                       /* Eğitim Sınıfı */
        public Branch?      Branch          { get; set; }                       /* Kayıt Yapan Şube */
        public Partner?     Partner         { get; set; }                       /* Kayda Gönderen Partner*/
        public Status?      Status          { get; set; }                       /* Durum : Fırsat, Aday, Öğrenci, Mezun  */
        public DateOnly     RegisterDate    { get; set; }                       /* Kursa Kayıt Tarihi   */
        public decimal      TrainingFee     { get; set; } = 0;                  /* Kurs Ücreti          */
        public decimal      Prepaid         { get; set; } = 0;                  /* Peşinat              */
        public decimal      PayMent1        { get; set; } = 0;                  /* Taksit Tutar1        */
        public DateOnly     PayDate1        { get; set; }                       /* Taksit 1             */
        public decimal      Payment2        { get; set; } = 0;                  /* Taksit 2             */
        public DateOnly     PayDate2        { get; set; }                       /* Taksit 2             */
        public decimal      Payment3        { get; set; } = 0;                  /* Taksit 3             */
        public DateOnly     PayDate3        { get; set; }                       /* Taksit 3             */
        public string       Notes1          { get; set; } = string.Empty;       /* Açıklamalar 1        */
        public string       Notes2          { get; set; } = string.Empty;       /* Açıklamalar 2        */
        public string       Notes3          { get; set; } = string.Empty;       /* Açıklamalar 3        */
        public string       Notes4          { get; set; } = string.Empty;       /* Açıklamalar 4        */

    }
}
