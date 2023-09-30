using University.Query.ViewModels.LecturerViewModels;

namespace University.Query.ViewModels.GetSubjectVIewModels
{
    internal class SubjectsWithLecturersVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public List<LecturerVm> lecturers { get; set; }



        
       



    }



}
