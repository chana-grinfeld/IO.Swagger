using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    [DataContract]
    public partial class ArithmeticExecuteModel
    {
        //int summary>
        /// Gets or Sets Number1
        /// </summary> 
        [Required]

        [DataMember(Name = "number1")]
        public int Number1 { get; set; }

        //int summary>
        /// Gets or Sets Number2
        /// </summary>
        [Required]

        [DataMember(Name = "number2")]
        public int Number2 { get; set; }
    }
}