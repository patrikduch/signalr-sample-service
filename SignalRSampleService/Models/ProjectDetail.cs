using System;

namespace SignalRSampleService.Models
{
    /// <summary>
    /// ProjectDetail model class, that represents all basic information about web project.
    /// </summary>
    public class ProjectDetail
    {

        /// <summary>
        /// 
        /// </summary>
        public ProjectDetail()
        {
            Id = new Guid();
        }


        /// <summary>
        ///  Gets or sets project identifier.
        /// </summary>
        public Guid Id { get; private set; }

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
