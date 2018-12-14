using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkBasics
{

    /// <summary>
    /// our settings database table represantational model
    /// </summary>
    public class SettingsDataModel
    {
        /// <summary>
        /// unique id for this entry
        /// </summary>
        [Key] //it creates a key
        public string Id { get; set; }
        /// <summary>
        /// settings name
        /// </summary>
        [Required] //it means that you have to provide a value for this field
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// settings value
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string Value { get; set; }
    }
}
