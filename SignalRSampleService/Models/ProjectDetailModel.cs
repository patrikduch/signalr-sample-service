using System;
using System.ComponentModel.DataAnnotations;

namespace SignalRSampleService.Models
{
    /// <summary>
    /// ProjectDetail model class, that represents all basic information about web project.
    /// </summary>
    public class ProjectDetailModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ProjectDetailModel()
        {
            Id = new Guid();
        }

        /// <summary>
        ///  Gets or sets project identifier.
        /// </summary>

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets project's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets author's name of the project.
        /// </summary>
        public string AuthorName { get; set; }
    }
}
