/*
 * Calculator API
 *
 * A simple calculator API that performs basic arithmetic operations based on the provided header.
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
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