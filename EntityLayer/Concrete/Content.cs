using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        //todo İçerik sınıfımız.
        [Key]
        public int ContentID { get; set; }
        //todo İçeriğin Değeri
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        //todo İLİŞKİLER
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        //todo Bos gecilebilir yaptık.
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }  
    }
}
