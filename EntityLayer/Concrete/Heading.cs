using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Diğer katmanlardan erişim sağlayabilmek için public ekliyoruz.
    public class Heading
    {
        //Property(Özellikleri) Ekliyoruz.
        [Key]
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        //ÇOK ÖNEMLİ! İLİŞKİ KURDUĞUMUZ TABLO İLE AYNI İSİM OLMALIDIR!

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //WRITER KISMI
        public int WriterID { get; set; }
        public virtual Writer Writers { get; set; }

        //CONTENT KISMIMIZ
        public ICollection<Content> Contents { get; set; }

    }
}
