using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch7.SharedAPI
{

    [MetadataType(typeof(CollaborationSpaceMetaData))]
    public partial class CollaborationSpace { }
    public class CollaborationSpaceMetaData
    {
        [Required]
        public object Title { get; set; }
    }

}
