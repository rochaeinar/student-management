
namespace Student_Management
{
    using System;
    using Models;
    using BusinessLayer;

    /// <summary>
    /// Student controller
    /// </summary>
    /// <seealso cref="Student_Management.Controller" />
    internal class StudentController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        public StudentController()
            : base(typeof(Student), new StudentLogic())
        {
        }
    }
}